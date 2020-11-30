using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADNInformation : MonoBehaviour
{
    public NuclManager.NuclEnum info;

    public NuclSpriterSO spriterSO;

    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriterSO.GetGeneratedSprite(info);
    }
}
