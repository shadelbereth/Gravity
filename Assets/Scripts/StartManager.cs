using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

    InputField playerName;
    Text placeholder;
    [SerializeField]
    string nextScene = "Test";
    [SerializeField]
    List<string> placeHolderTexts;
    int count;

    private void Start()
    {
        playerName = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<InputField>();
        placeholder = GameObject.FindGameObjectWithTag("Placeholder").GetComponent<Text>();
        count = 0;
        placeholder.text = placeHolderTexts[count];
        PlayerPrefs.DeleteKey("PlayerName");
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName.text = PlayerPrefs.GetString("PlayerName");
        }
    }

    public void ValidateStartInfo ()
    {
        if (playerName.text.Equals(""))
        {
            count++;
            placeholder.text = placeHolderTexts[count % placeHolderTexts.Count];
            return;
        }
        PlayerPrefs.SetString("PlayerName", playerName.text);
        SceneManager.LoadScene(nextScene);
    }
}
