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

    public CellStateSO cellState;

    void Start()
    {
        foundImage.sprite = cellState.foundImage;

        Nucl_0.sprite = cellState.Nucl_0.sprite;
        Nucl_1.sprite = cellState.Nucl_1.sprite;
        Nucl_2.sprite = cellState.Nucl_2.sprite;
        Nucl_3.sprite = cellState.Nucl_3.sprite;
        Nucl_4.sprite = cellState.Nucl_4.sprite;
        
        UpdateUI();
    }

    public void UpdateUI()
    {
        foundImage.gameObject.SetActive(cellState.Found);

        Nucl_0.gameObject.SetActive(cellState.Found || cellState.Nucl_0.Found);
        Nucl_1.gameObject.SetActive(cellState.Found || cellState.Nucl_1.Found);
        Nucl_2.gameObject.SetActive(cellState.Found || cellState.Nucl_2.Found);
        Nucl_3.gameObject.SetActive(cellState.Found || cellState.Nucl_3.Found);
        Nucl_4.gameObject.SetActive(cellState.Found || cellState.Nucl_4.Found);
    }
}
