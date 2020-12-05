using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADNMovement : MonoBehaviour
{
    private bool move = true;

    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!move)
            return;

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void StopMoving()
    {
        move = false;
    }

    public void StartMoving()
    {
        move = true;
    }
}
