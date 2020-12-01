using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellStateManager : MonoBehaviour
{
    public Image foundImage;
    public Image Nucl_0;
    public Image Nucl_1;
    public Image Nucl_2;
    public Image Nucl_3;
    public Image Nucl_4;

    public NuclSpriterSO nuclSpriter;
    public CellStateSO cellState;

    void Start()
    {
        foundImage.sprite = cellState.foundImage;

        Nucl_0.sprite = nuclSpriter.GetUISprite(cellState[0]);
        Nucl_1.sprite = nuclSpriter.GetUISprite(cellState[1]);
        Nucl_2.sprite = nuclSpriter.GetUISprite(cellState[2]);
        Nucl_3.sprite = nuclSpriter.GetUISprite(cellState[3]);
        Nucl_4.sprite = nuclSpriter.GetUISprite(cellState[4]);
        
        UpdateUI();
    }

    public void UpdateUI()
    {
        foundImage.gameObject.SetActive(cellState.Found);

        Nucl_0.gameObject.SetActive(cellState.Found || cellState.isNuclFound(0));
        Nucl_1.gameObject.SetActive(cellState.Found || cellState.isNuclFound(1));
        Nucl_2.gameObject.SetActive(cellState.Found || cellState.isNuclFound(2));
        Nucl_3.gameObject.SetActive(cellState.Found || cellState.isNuclFound(3));
        Nucl_4.gameObject.SetActive(cellState.Found || cellState.isNuclFound(4));
    }
}
