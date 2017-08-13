using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarPicker : MonoBehaviour {

    [SerializeField]
    Color color = Color.white;

    public delegate void OnAvatarColorChange();
    public event OnAvatarColorChange AvatarColorChanged;

    private void Start()
    {
        Button button = GetComponent<Button>();
        ColorBlock newTransition = button.colors;
        newTransition.normalColor = color;
        newTransition.highlightedColor = new Color(color.r - 10f / 255f, color.g - 10f / 255f, color.b - 10f / 255f);
        newTransition.pressedColor = new Color(color.r - 55f / 255f, color.g - 55f / 255f, color.b - 55f / 255f);
        newTransition.disabledColor = new Color(color.r - 55f / 255f, color.g - 55f / 255f, color.b - 55f / 255f, color.a / 2);
        button.colors = newTransition;
        button.onClick.AddListener(ChangeAvatarColor);
        AvatarColorChanged += GameObject.FindGameObjectWithTag("Player").GetComponent<AvatarManager>().UpdateAvatarColor;
    }

    public void ChangeAvatarColor ()
    {
        PlayerPrefs.SetFloat("AvatarColorRed", color.r);
        PlayerPrefs.SetFloat("AvatarColorGreen", color.g);
        PlayerPrefs.SetFloat("AvatarColorBlue", color.b);
        AvatarColorChanged.Invoke();
    }
}
