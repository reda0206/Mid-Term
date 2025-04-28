using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if(Collision.gameObject.CompareTag("Player"))
        {
            Collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(9999);
        }
    }
}
