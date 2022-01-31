using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    [SerializeField] int Coins = 100;
    int BonusCoins = 25;
    //float delay = 1f;
    Text Cointext;

    
    void Start()
    {
        Cointext = GetComponent<Text>();

       StartCoroutine(AddCoinsAfterTime());

        UpdateCoinText();
        

    }
    private void Update()
    {
        
        
    }

    IEnumerator AddCoinsAfterTime()
    {   
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Coins += BonusCoins;
            UpdateCoinText();
        }
    }
    private void UpdateCoinText()
    {
        Cointext.text = Coins.ToString();
    }

    public void AddCoins(int KillRewardCoins)
    {
        Coins += KillRewardCoins;
        UpdateCoinText();
    }

   public void SpendCoins(int amount)
    {
        if (Coins >= amount)
        {
            Coins -= amount;
            UpdateCoinText();
        }
    }

    public bool HaveEnoughCoin(int amount)
    {
        return Coins >= amount;
    }
}
