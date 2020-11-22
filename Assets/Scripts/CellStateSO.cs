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
    [TextArea(3, 5)]
    public string foundMessage;

    [System.Serializable]
    public class NuclData
    {
        public Sprite sprite;
        public NuclManager.NuclEnum value;
        [NonSerialized]
        private bool found = false;

        public bool Found
        {
            get => found;
            set => found = value;
        }
    }

    public NuclData Nucl_0;
    public NuclData Nucl_1;
    public NuclData Nucl_2;
    public NuclData Nucl_3;
    public NuclData Nucl_4;

    [NonSerialized]
    private bool found = false;

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
        var nucl = getNucl(index);

        if (nucl != null) return nucl.Found;
        else return false;
    }

    public void findNucl(int index)
    {
        var nucl = getNucl(index);
        
        if (nucl != null)
        {
            nucl.Found = true;
            updatedGameEvent.Raise();
        }
    }

    public NuclData getNucl(int index)
    {
        switch(index)
        {
            case 0: return Nucl_0;
            case 1: return Nucl_1;
            case 2: return Nucl_2;
            case 3: return Nucl_3;
            case 4: return Nucl_4;
        }

        return null;
    }

    public string Model => NuclManager.ToString(Nucl_0.value, Nucl_1.value, Nucl_2.value, Nucl_3.value, Nucl_4.value);
}
