using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    GameManager Player;
    private Image FuelMeasure;
    public float CurrentFuel;
    private float MaxFuel = 100f;



    void Start()
    {
        //Find
        FuelMeasure = GetComponent<Image>();
        Player = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        CurrentFuel = Player.FuelLevel;
        FuelMeasure.fillAmount = CurrentFuel/MaxFuel;
    }
}
