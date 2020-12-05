using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADNGenerator : MonoBehaviour
{
    public ADNInformation prefab;
    public float speed = 0.5f;
    public float size = 0.885f;

    private float timer = 0f;

    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (! started)
            return;
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            GenerateOne();
            timer = size / speed;
        }
    }

    public void GenerateOne()
    {
        int idx = UnityEngine.Random.Range(0, Enum.GetNames(typeof(NuclManager.NuclEnum)).Length - 1); // -1 to not have eNuclX
        
        var info = Instantiate(prefab, transform) as ADNInformation;
        info.transform.localPosition = Vector3.zero;
        info.info = (NuclManager.NuclEnum) idx;
        info.GetComponent<ADNMovement>().speed = speed;
    }

    public void StopGenerating()
    {
        started = false;
    }

    public void StartGenerating()
    {
        started = true;
    }
}
