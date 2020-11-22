using System.Collections;
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
                return;
            }
            
            i++;
        }

        // if we are here, it means that its not a successful try
        // let's give a hint

        onNewMessage.sentString = "YOU DON'T SEEM TO KNOW WHAT YOU ARE DOING ! OKAY I WILL GIVE AN ADVICE !! LOOK ON MY NOTEPAD (ON LEFT) UNDER THE UNDISCOVERED CELLS FORMULA !";
        onNewMessage.Raise();

        GiveAHint();
    }

    public void GiveAHint()
    {
        onUnsuccessfulTry.Raise();

        for(int i = 0; i < CellStates.Count; i++)
        {
            var state = CellStates[i];
            for (int j = 0; j < 5; j++)
            {
                if (! state.isNuclFound(j))
                {
                    state.findNucl(j);
                    return;
                }
            }
        }
    }
}
