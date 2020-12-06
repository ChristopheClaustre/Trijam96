using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADNGeneratorPlacer : MonoBehaviour
{
    public RectTransform UITransform;

    // Start is called before the first frame update
    void Start()
    {
        Place();
    }

    void Update()
    {
        Place();
    }

    void Place()
    {
        Vector3[] corners = new Vector3[4];
        UITransform.GetWorldCorners(corners);
        Vector2 lCenterOnScreen = (corners[0] + corners[1] + corners[2] + corners[3]) / 4;
        Vector3 lCenterOnWorld = Camera.main.ScreenToWorldPoint(lCenterOnScreen);
        lCenterOnWorld.z = 0;
        transform.position = lCenterOnWorld;
    }
}
