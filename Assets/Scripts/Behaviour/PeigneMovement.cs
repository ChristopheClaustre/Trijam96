using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeigneMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (! Screen.safeArea.Contains(Input.mousePosition))
            return;
        
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePos.z = 0;

        transform.position = worldMousePos;
    }
}
