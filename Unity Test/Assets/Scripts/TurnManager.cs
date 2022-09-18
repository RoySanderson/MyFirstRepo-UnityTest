using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    private int activePlayerIndex;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            activePlayerIndex = 1;
        }
    }

    public bool PlayerIsActive(int index)
    {
        return index == activePlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void ChangeTurn()
    {
        if(activePlayerIndex == 1)
        {
            activePlayerIndex = 2;
        }
        else if(activePlayerIndex == 2)
        {
            activePlayerIndex = 1;
        }
    }
}
