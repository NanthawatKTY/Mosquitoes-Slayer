using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    [SerializeField] int starCost ;


    public int GetStarCost() //ต้องเป็น int
    {
        return starCost;
    }


    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }


}
