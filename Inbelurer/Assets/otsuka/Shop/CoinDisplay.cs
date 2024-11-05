using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    public Text coinText;
    private static int coins = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.text = "ÉRÉCÉì: ñá" + coins.ToString("D3");
    }
}
