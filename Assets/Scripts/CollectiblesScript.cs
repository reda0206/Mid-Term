using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesScript : MonoBehaviour
{
    public AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ObtainCoin();
            Debug.Log("You got a coin!");
            AudioSource.PlayClipAtPoint(coinSound, transform.position, 1f);
            Destroy(gameObject);
        }
    }
}
