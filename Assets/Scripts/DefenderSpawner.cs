using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] Defenders defender;

    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());
     
    }

    public void SetSelectedDefender(Defenders defenderToSelect)
    {
        defender = defenderToSelect;
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
    }
}
