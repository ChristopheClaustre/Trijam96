using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEventSystem;

[CreateAssetMenu(fileName = "CellState", menuName = "Cell State")]
public class CellStateSO : ScriptableObject
{
    public GameEvent updatedGameEvent;
    public Sprite foundImage;
    [TextArea(3, 5)] public string foundMessage;
    public string model;

    [NonSerialized]
    private bool found = false;

    [NonSerialized]
    private List<int> foundModelPart = new List<int>();

    public bool Found
    {
        get => found;
        set
        {
            if (value != found)
            {
                found = value;
                updatedGameEvent.Raise();
            }
        }
    }

    public bool isNuclFound(int index)
    {
        return foundModelPart.Contains(index);
    }

    public void findNucl(int index)
    {
        if (isNuclFound(index))
            return;
        
        foundModelPart.Add(index);
        updatedGameEvent.Raise();
    }

    public NuclManager.NuclEnum this[int idx] => NuclManager.FromChar(model[idx]);
    
    public string Model => model;
}
