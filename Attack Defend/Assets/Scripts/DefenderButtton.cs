using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButtton : MonoBehaviour
{
   [SerializeField] Defender defenderPrefab;

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType <DefenderButtton>();
        foreach(DefenderButtton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(0,0,0,255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<PlaceDefender>().PlaceSelectedDefender(defenderPrefab);

    }

}
