using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
