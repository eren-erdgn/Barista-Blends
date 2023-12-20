using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cup : MonoBehaviour
{
    private int espressoLevel = 0;
    private int milkLevel = 0;
    private int waterLevel = 0;
    private int filterCoffeeLevel = 0;
    private int MilkFoamLevel = 0;
    
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        switch (other.tag)
        {
            case "Espresso":
                espressoLevel++;
                break;
            case "Milk":
                milkLevel++;
                break;
            case "Water":
                waterLevel++;
                break;
            case "FilterCoffee":
                filterCoffeeLevel++;
                break;
            case "MilkFoam":
                MilkFoamLevel++;
                break;
        }
    }
}
