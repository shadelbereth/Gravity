using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardGiver : MonoBehaviour {

    public float value = 120;
    int numberOfArea = 12;
    List<RewardArea> areaToExplore = new List<RewardArea>();

    struct RewardArea
    {
        public int beginAngle;
        public int endAngle;
        public int polarity;
        public float value;
    }

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 180; i += 360 / numberOfArea)
        {
            int[] polarity = new int[] { 1, -1 };
            for (int j = 0; j < polarity.Length; j++)
            {
                RewardArea area = new RewardArea();
                area.beginAngle = i;
                area.endAngle = i + 360 / numberOfArea;
                area.polarity = polarity[j];
                area.value = value / numberOfArea;
                areaToExplore.Add(area); 
            }
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (areaToExplore.Count > 0)
        {
            RewardHolder holder = collision.GetComponent<RewardHolder>();
            if (holder != null)
            {
                float explorationAngle = Vector2.Angle(transform.up, holder.transform.position - transform.position);
                float polarity = holder.transform.position.x - transform.position.x;
                bool found = false;
                int i = 0;
                while (!found & i < areaToExplore.Count)
                {
                    if (areaToExplore[i].beginAngle <= explorationAngle & areaToExplore[i].endAngle > explorationAngle & areaToExplore[i].polarity * polarity >= 0)
                    {
                        holder.GetReward(areaToExplore[i].value);
                        areaToExplore.Remove(areaToExplore[i]);
                    }
                    i++;
                }
            } 
        }
    }
}
