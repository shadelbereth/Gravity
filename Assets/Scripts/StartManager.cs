using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

    InputField playerName;
    [SerializeField]
    string nextScene = "Test";

    private void Start()
    {
        playerName = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<InputField>();
    }

    public void ValidateStartInfo ()
    {
        if (playerName.text.Equals(""))
        {
            return;
        }
        PlayerPrefs.SetString("PlayerName", playerName.text);
        SceneManager.LoadScene(nextScene);
    }
}
