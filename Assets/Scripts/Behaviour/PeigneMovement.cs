using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeigneMovement : MonoBehaviour
{
    public List<RectTransform> movementZones;

    private bool userManagingComb = false;

    public bool UserManagingComb { get => userManagingComb; }

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (movementZones.Count != 0)
        {
            bool contains = false;
            int i = 0;
            while (i < movementZones.Count && ! contains)
            {
                contains = RectTransformUtility.RectangleContainsScreenPoint(movementZones[i], Input.mousePosition);
                i++;
            }
            if (! contains)
                return false;
        }

        return true;
    }
}
