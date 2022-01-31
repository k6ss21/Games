using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenealty = 25;

    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }
    public void RewardGold()
    {
        if (bank == null) { return; }
        bank.Deposit(goldReward);
    }
    public void PenaltyGold()
    {
        if (bank == null) { return; }
        bank.Withdraw(goldPenealty);
    }
}

