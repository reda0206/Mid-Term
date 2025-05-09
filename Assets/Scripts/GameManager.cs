using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        coinsText.text = coinsObtained + "/3 Coins";
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
        coinsText.text = coinsObtained + "/3 Coins";
        Debug.Log(coinsObtained + "/3 Coins");

        if (coinsObtained == 3)
        {
            Debug.Log("You have obtained all coins!");
            SceneManager.LoadScene("WinScene");
        }
    }
}
