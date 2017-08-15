using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardHolder : MonoBehaviour {

    float gainedReward = 0;

    public delegate void OnRewardGain(float rewardGained);
    public event OnRewardGain RewardGained;

    private void Start()
    {
        RewardGained.Invoke(gainedReward);
    }

    public void GetReward (float value)
    {
        if (value > 0)
        {
            gainedReward += value;
            RewardGained.Invoke(gainedReward);
        }
    }
}
