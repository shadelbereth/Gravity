using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour {

    Rigidbody2D m_rigidbody;
    [SerializeField]
    float initialSpeed = 100;
    [SerializeField]
    float speedLoss = 5;
    [SerializeField]
    float fuel = 90;
    [SerializeField]
    float speedBoost = 10;
    [SerializeField]
    float fuelUsedByBoost = 10;

    public delegate void OnFuelLevelChanged(float fuel);
    public event OnFuelLevelChanged FuelLevelChange;

	// Use this for initialization
	void Start () {
        Physics2D.gravity = Vector3.zero;
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_rigidbody.AddForce(transform.up * initialSpeed);
        if (FuelLevelChange != null)
        {
            FuelLevelChange.Invoke(fuel);
        }
	}
	
	// Update is called once per frame
	void Update () {
        print(m_rigidbody.velocity.magnitude);
        if (m_rigidbody.velocity.magnitude > 0.01)
            m_rigidbody.AddForce(transform.up * (-1) * speedLoss * Time.deltaTime);
    }

    public void Boost ()
    {
        if (fuel >= fuelUsedByBoost)
        {
            m_rigidbody.AddForce(transform.up * speedBoost);
            fuel -= fuelUsedByBoost;
            if (FuelLevelChange != null)
            {
                FuelLevelChange.Invoke(fuel);
            }
        }
    }
}
