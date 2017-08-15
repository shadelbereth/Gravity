using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateRewardUI : MonoBehaviour {

    Text rewardUI;

    private void OnEnable()
    {
        rewardUI = GetComponent<Text>();
        RewardHolder player = GameObject.FindGameObjectWithTag("Player").GetComponent<RewardHolder>();
        player.RewardGained += UpdateUI;
    }

    public void UpdateUI(float rewardGained)
    {
        rewardUI.text = rewardGained.ToString();
    }
}
