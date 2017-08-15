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
    GameObject infoUI;
    GameObject tutorialUI;
    Transform cameraTransform;

    private void Start()
    {
        playerName = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<InputField>();
        placeholder = GameObject.FindGameObjectWithTag("TextToChange").GetComponent<Text>();
        infoUI = GameObject.FindGameObjectWithTag("InfoUI");
        tutorialUI = GameObject.FindGameObjectWithTag("TutorialUI");
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        cameraTransform.position = new Vector3(0, 0, -10);
        tutorialUI.SetActive(false);
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
        infoUI.SetActive(false);
        tutorialUI.SetActive(true);
        cameraTransform.position = new Vector3(20, 0, -10);
    }

    public void StartMission ()
    {
        SceneManager.LoadScene(nextScene);
    }
}
