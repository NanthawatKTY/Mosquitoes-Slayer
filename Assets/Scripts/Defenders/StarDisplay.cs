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

    public bool HaveEnoughStars(int amount) //amount = defender's price
    {
        return stars >= amount;
    }


    public void AddStars(int amountAdd)  //amountAdd = Stars amount add
    {
        stars += amountAdd;
        SFXManagement.PlaySound("qurazy_quoin");
        UpdateDisplay();
    }

    public void SpendStars(int amount) //decrease with defender price
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }   
    }
}
