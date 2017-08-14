using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    [SerializeField]
    float fieldRadiusCoeff = 5;
    [SerializeField]
    string fieldLayerName = "Gravity Field";
    [SerializeField]
    float maxVelocityCoeff = 10;
    [SerializeField]
    float speedBoostCoeff = 4;
    [SerializeField]
    float speedToEscapeCoeff = 6;

	// Use this for initialization
	void Start () {
        float planetRadius = GetComponent<CircleCollider2D>().radius;
        GameObject fieldHolder = new GameObject(gameObject.name + " Orbit");
        fieldHolder.transform.SetParent(gameObject.transform, false);
        fieldHolder.transform.position = gameObject.transform.position;
        float planetScale = fieldHolder.transform.lossyScale.y;
        CircleCollider2D orbitZone = fieldHolder.AddComponent<CircleCollider2D>();
        orbitZone.isTrigger = true;
        orbitZone.radius = planetRadius * fieldRadiusCoeff;
        fieldHolder.AddComponent<GravityField>().Initialize(maxVelocityCoeff * planetRadius * planetScale, speedBoostCoeff * planetRadius * planetScale, speedToEscapeCoeff * planetRadius * planetScale);
        GameObject fieldView = new GameObject(gameObject.name + " Orbit Visualization");
        fieldView.transform.SetParent(gameObject.transform, false);
        fieldView.transform.position = gameObject.transform.position;
        fieldView.transform.localScale = new Vector3(fieldRadiusCoeff, fieldRadiusCoeff, fieldRadiusCoeff);
        fieldView.layer = LayerMask.NameToLayer(fieldLayerName);
        SpriteRenderer fieldSprite = fieldView.AddComponent<SpriteRenderer>();
        fieldSprite.sprite = GetComponent<SpriteRenderer>().sprite;
        fieldSprite.color = GetComponent<SpriteRenderer>().material.color;
        fieldSprite.color = new Color(fieldSprite.color.r, fieldSprite.color.g, fieldSprite.color.b, fieldSprite.color.a / 2);
	}
}
