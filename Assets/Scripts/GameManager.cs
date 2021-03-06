﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEventSystem;

public class GameManager : MonoBehaviour
{
    public List<CellStateSO> CellStates;

    public GameEvent onSuccessfulTry;
    public GameEvent onUnsuccessfulTry;
    public GameEvent onNewMessage;
    public GameEvent onGameEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Try(string candidate)
    {
        int i = 0;
        while(i < CellStates.Count)
        {
            var state = CellStates[i];
            if (NuclManager.Compare(candidate, state.Model))
            {
                state.Found = true;
                onNewMessage.sentString = state.foundMessage;
                onNewMessage.Raise();
                onSuccessfulTry.Raise();
                CellStates.RemoveAt(i);
                if (CellStates.Count == 0)
                    onGameEnd.Raise();
                return;
            }
            
            i++;
        }

        // if we are here, it means that its not a successful try
        // let's give a hint

        onNewMessage.sentString = "YOU DON'T SEEM TO KNOW WHAT YOU ARE DOING ! OKAY I WILL GIVE AN ADVICE !! LOOK ON MY NOTEPAD (ON LEFT) UNDER THE UNDISCOVERED CELLS FORMULA !";
        onNewMessage.Raise();

        GiveAHint(candidate);
    }

    public void GiveAHint(string candidate)
    {
        onUnsuccessfulTry.Raise();

        for(int i = 0; i < CellStates.Count; i++)
        {
            var state = CellStates[i];
            List<int> indexes = NuclManager.CorrectIndices(candidate, state.Model);
            for (int j = 0; j < indexes.Count; j++)
            {
                state.findNucl(indexes[j]);
            }
        }
    }
}
