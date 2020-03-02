using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defenders defender;
    GameObject defendersParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefendersParent();
    }

    private void CreateDefendersParent()
    {
        defendersParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defendersParent)
        {
            defendersParent = new GameObject(DEFENDER_PARENT_NAME);
        
        }
    }

    private void OnMouseDown()
    {
        if (defender == null) { return; }
        AttempToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defenders defenderToSelect)
    {
        defender = defenderToSelect;
    }


    private void AttempToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
        //if we have enough money
            //Spawn the defender
            //spend the stars
    }


    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);                  //Place denfender on grid
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {

        Defenders newDefender = Instantiate(defender, roundedPos, transform.rotation) as Defenders;
        newDefender.transform.parent = defendersParent.transform;
    }
}
