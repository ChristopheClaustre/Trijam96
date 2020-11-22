using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADNGenerator : MonoBehaviour
{
    public List<GameObject> prefabs;
    public float speed = 0.5f;
    public float size = 0.885f;

    private float timer = 0f;

    public bool started = false; 

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
        var rnd = new System.Random(DateTime.Now.Millisecond);
        int idx = rnd.Next(0, prefabs.Count);

        var go = Instantiate(prefabs[idx], transform);
        go.transform.localPosition = Vector3.zero;
        go.GetComponent<ADNMovement>().speed = speed;
    }
}
