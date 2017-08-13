using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour {

    SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        UpdateAvatarColor();
	}

    public void UpdateAvatarColor ()
    {
        if (PlayerPrefs.HasKey("AvatarColorRed") && PlayerPrefs.HasKey("AvatarColorGreen") && PlayerPrefs.HasKey("AvatarColorBlue"))
        {
            sprite.color = new Color(PlayerPrefs.GetFloat("AvatarColorRed"), PlayerPrefs.GetFloat("AvatarColorGreen"), PlayerPrefs.GetFloat("AvatarColorBlue"));
        }
    }
}
