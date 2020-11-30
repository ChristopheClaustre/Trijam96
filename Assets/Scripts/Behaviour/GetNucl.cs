using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNucl : MonoBehaviour
{
    public Collider2D actualCollider2D = null;

    public SpriteRenderer nuclSpriteRenderer = null;

    public NuclSpriterSO spriterSO;

    // Start is called before the first frame update
    void Start()
    {
        nuclSpriteRenderer.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        actualCollider2D = collider;
        nuclSpriteRenderer.sprite = spriterSO.GetCombSprite(ADNInfo.info);
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider == actualCollider2D)
        {
            actualCollider2D = null;
            nuclSpriteRenderer.sprite = null;
        }
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
