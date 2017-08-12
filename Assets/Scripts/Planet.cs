using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

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
        orbitZone.radius = planetRadius * 5;
        fieldHolder.AddComponent<GravityField>().Initialize(maxVelocityCoeff * planetRadius * planetScale, speedBoostCoeff * planetRadius * planetScale, speedToEscapeCoeff * planetRadius * planetScale);
	}
}
