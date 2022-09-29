using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTeleport : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public HealthBarScript healthBar;
    public float posX;
    public float posY;
    public float posZ;


    void Start()
    {
        
    }

    void Update()
    {
       if (playerHealth.currentHealth <= 0)
        {
            gameObject.transform.position = new Vector3(posX, posY, posZ);
            playerHealth.currentHealth = 100;
            healthBar.MaxHealth(100);
        } 
    }
}
