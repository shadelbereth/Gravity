using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFuelUI : MonoBehaviour {

    Text fuelUI;

    private void OnEnable()
    {
        RocketMove player = GameObject.FindGameObjectWithTag("Player").GetComponent<RocketMove>();
        fuelUI = GetComponent<Text>();
        player.FuelLevelChange += UpdateUI;
    }

    private void OnDisable()
    {
        RocketMove player = GameObject.FindGameObjectWithTag("Player").GetComponent<RocketMove>();
        player.FuelLevelChange -= UpdateUI;
    }

    public void UpdateUI(float fuelLevel)
    {
        fuelUI.text = fuelLevel.ToString();
    }
}
