using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMissionManager : MonoBehaviour {

    [SerializeField]
    string flavourText = "Write here some flavour text with {0} instead of the player name.";
    [SerializeField]
    string rewardText = "Write here a congratulation text about the score with {0} instead of the score.";
    [SerializeField]
    string startScene = "Start";
    [SerializeField]
    string playScene = "Test";

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("TextToChange").GetComponent<Text>().text = flavourText.Replace("{0}", PlayerPrefs.GetString("PlayerName"));
        GameObject.FindGameObjectWithTag("RewardText").GetComponent<Text>().text = rewardText.Replace("{0}", PlayerPrefs.GetFloat("Score").ToString());
    }

    public void Restart (bool newPlayer)
    {
        if (newPlayer)
        {
            PlayerPrefs.DeleteKey("PlayerName");
            PlayerPrefs.DeleteKey("AvatarColorRed");
            PlayerPrefs.DeleteKey("AvatarColorGreen");
            PlayerPrefs.DeleteKey("AvatarColorBlue");
            SceneManager.LoadScene(startScene);
        }
        else
        {
            SceneManager.LoadScene(playScene);
        }
    }
}
