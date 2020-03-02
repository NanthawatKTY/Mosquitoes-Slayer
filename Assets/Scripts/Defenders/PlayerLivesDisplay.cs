using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesDisplay : MonoBehaviour
{

    [SerializeField] int lives = 10;
    [SerializeField] int damage = 1;
    Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
       livesText.text = lives.ToString();
    }

    public void TakeLife() //decrease life per 1
    {

            lives -= damage;
            UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
