using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PeigneMovement : MonoBehaviour
{
    private bool userManagingComb = false;

    public bool UserManagingComb { get => userManagingComb; }

    private List<GraphicRaycaster> foundRaycaster;
    EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        foundRaycaster = FindObjectsOfType<GraphicRaycaster>(true).ToList();
        eventSystem = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (! checkPosition(Input.mousePosition))
        {
            userManagingComb = false;
            MoveComb(Screen.safeArea.size * 0.5f);
            return;
        }
        
        userManagingComb = true;
        MoveComb(Input.mousePosition);
    }

    public void MoveComb(Vector2 screenPosition)
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(screenPosition);
        worldMousePos.z = 0;

        transform.position = worldMousePos;
    }

    public bool checkPosition(Vector2 screenPosition)
    {
        if (! Screen.safeArea.Contains(Input.mousePosition))
            return false;

        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = screenPosition;

        foreach (var raycaster in foundRaycaster)
        {
            if (! raycaster.gameObject.activeInHierarchy)
                continue;
            
            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);
            if (results.Count > 0)
                return false;
        }

        return true;
    }
}
