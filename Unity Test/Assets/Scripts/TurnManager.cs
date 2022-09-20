using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    private int activePlayerIndex;
    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            activePlayerIndex = 1;
            camera1.enabled = true;
            camera2.enabled = false;
        }
        else
            Destroy(this.gameObject);
       
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
            camera2.enabled = true;
            camera1.enabled = false;

        }
        else if(activePlayerIndex == 2)
        {
            activePlayerIndex = 1;
            camera1.enabled= true;
            camera2.enabled = false;
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            ChangeTurn();
        }
    }
}
