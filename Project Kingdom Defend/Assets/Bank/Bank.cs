using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField]int currentBalance;
    [SerializeField] TextMeshProUGUI displayText;
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        
        currentBalance = startingBalance;
        UpdateDisplay();
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        if(currentBalance< 0)
        {
            ReloadSene();
        }
    }

    private static void ReloadSene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    void UpdateDisplay()
    {
        displayText.text =  currentBalance.ToString();

    }
}

