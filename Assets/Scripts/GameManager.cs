using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int coinsObtained = 0;
    public TextMeshProUGUI coinsText;
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

    private void Start()
    {
        coinsText.text = "Coins = " + coinsObtained;
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
        coinsText.text = "Coins = " + coinsObtained;
        Debug.Log("Coins = " + coinsObtained);
    }
}
