using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int coinsObtained = 0;

    private void Awake()
    {
       if (Instance == null)
        {
            Instance = this;
        }
       else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    public void ObtainCoin()
    {
        coinsObtained++;
        Debug.Log("Coins = " + coinsObtained);
    }
}
