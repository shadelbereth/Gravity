using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFuelUI : MonoBehaviour {

    Text fuelUI;

	// Use this for initialization
	void Start () {
        fuelUI = GetComponent<Text>();
	}

    private void OnEnable()
    {
        RocketMove player = GameObject.FindGameObjectWithTag("Player").GetComponent<RocketMove>();
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
