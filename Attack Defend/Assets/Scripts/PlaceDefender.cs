using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDefender : MonoBehaviour
{

    Defender shooterPrefab;
    
    

    private void OnMouseDown()
    {
        if (!shooterPrefab)
        {
            Debug.Log("Defender not selected.");
            return;
        }
        AttemptToPlaceDfender(GetSqaureClicked());
    }
   
    private Vector2 GetSqaureClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = GridPos(worldPos);
        return gridPos;

    }

    private Vector2 GridPos(Vector2 worldpos)
    {
        float newX = Mathf.RoundToInt(worldpos.x);
        float newY = Mathf.RoundToInt(worldpos.y);
        return new Vector2 (newX, newY);
    }
    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(shooterPrefab, worldPos, Quaternion.identity);
    }

    public void PlaceSelectedDefender(Defender defenderFromBotton)
    {
       shooterPrefab = defenderFromBotton;
        
    }

    private void AttemptToPlaceDfender(Vector2 gridPos)
    {
        var coinScript = FindObjectOfType<CoinScript>();
        int defenderCost = shooterPrefab.GetCoinCost();
        if (coinScript.HaveEnoughCoin(defenderCost))
        {
            SpawnDefender(gridPos);
            coinScript.SpendCoins(defenderCost);
        }
    }
   
}

