using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using GameEventSystem;

public class PeigneTry : MonoBehaviour
{
    public GameEvent onBadClick;
    public GameEvent onGoodClick;

    public UnityEvent onValidPositionEntered;
    public UnityEvent onValidPositionLeaved;

    List<GetNucl> getNucls;

    private PeigneMovement movementScript;

    private bool validPosition = false;

    public bool ValidPosition => validPosition;

    void Start()
    {
        movementScript = GetComponent<PeigneMovement>();
        getNucls = GetComponentsInChildren<GetNucl>().ToList();
        Debug.Assert(getNucls.Count == 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (! movementScript.UserManagingComb)
            return;

        string candidate = "";

        int i = 0;
        while (i < getNucls.Count && getNucls[i].ADNInfo != null)
        {
            candidate += NuclManager.ToChar(getNucls[i].ADNInfo.info);
            i++;
        }

        bool isValid = candidate.Length == 5;
        if (validPosition != isValid)
        {
            validPosition = isValid;
            if (validPosition)
                onValidPositionEntered.Invoke();
            else
                onValidPositionLeaved.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (validPosition)
            {
                if (onGoodClick)
                {
                    onGoodClick.sentString = candidate;
                    onGoodClick.Raise();
                }
            }
            else
            {
                if (onBadClick) onBadClick.Raise();
            }
        }
    }
}
