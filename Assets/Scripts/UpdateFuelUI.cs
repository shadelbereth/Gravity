using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFuelUI : MonoBehaviour {

    Text fuelUI;

    private void OnEnable()
    {
        fuelUI = GetComponent<Text>();
        RocketMove player = GameObject.FindGameObjectWithTag("Player").GetComponent<RocketMove>();
        if (player != null)
            player.FuelLevelChange += UpdateUI;
    }

    private void OnDisable()
    {
        RocketMove player = GameObject.FindGameObjectWithTag("Player").GetComponent<RocketMove>();
        if (player != null)
            player.FuelLevelChange -= UpdateUI;
    }

    public void UpdateUI(float fuelLevel)
    {
        fuelUI.text = fuelLevel.ToString();
    }
}
