using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNucl : MonoBehaviour
{
    public Collider2D actualCollider2D = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        actualCollider2D = collider;
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider == actualCollider2D)
            actualCollider2D = null;
    }

    public ADNInformation ADNInfo
    {
        get
        {
            if (actualCollider2D == null) return null;

            var info = actualCollider2D.GetComponent<ADNInformation>();
            if (info == null) return null;

            return info;
        }
    }
}
