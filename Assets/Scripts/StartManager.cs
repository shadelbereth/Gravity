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
    List<string> placeholderTexts;
    int placeholderTextDisplayCount;

    private void Start()
    {
        playerName = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<InputField>();
        placeholder = GameObject.FindGameObjectWithTag("TextToChange").GetComponent<Text>();
        placeholderTextDisplayCount = 0;
        placeholder.text = placeholderTexts[placeholderTextDisplayCount];
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName.text = PlayerPrefs.GetString("PlayerName");
        }
    }

    public void ValidateStartInfo ()
    {
        if (playerName.text.Equals(""))
        {
            placeholderTextDisplayCount++;
            placeholder.text = placeholderTexts[placeholderTextDisplayCount % placeholderTexts.Count];
            return;
        }
        PlayerPrefs.SetString("PlayerName", playerName.text);
        SceneManager.LoadScene(nextScene);
    }
}
