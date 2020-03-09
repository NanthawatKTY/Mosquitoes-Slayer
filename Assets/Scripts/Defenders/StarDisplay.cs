using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{

    [SerializeField] int stars;
    Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }


    public void AddStars(int amount)
    {
        stars += amount;
        SFXManagement.PlaySound("qurazy_quoin");
        UpdateDisplay();
    }

    public void SpendStars(int amount) //decrease
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }   
    }
}
