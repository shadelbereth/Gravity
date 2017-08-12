using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour {

    Rigidbody2D m_rigidbody;
    [SerializeField]
    float initialSpeed = 20;
    [SerializeField]
    float speedLoss = 1;
    [SerializeField]
    float fuel = 90;
    [SerializeField]
    float speedBoost = 20;
    [SerializeField]
    float fuelUsedByBoost = 10;

    public delegate void OnFuelLevelChanged(float fuel);
    public event OnFuelLevelChanged FuelLevelChange;

	// Use this for initialization
	void Start () {
        Physics2D.gravity = Vector3.zero;
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_rigidbody.velocity = transform.up * initialSpeed;
        if (FuelLevelChange != null)
        {
            FuelLevelChange.Invoke(fuel);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (m_rigidbody.velocity.magnitude > 0.01)
            m_rigidbody.velocity = transform.up * m_rigidbody.velocity.magnitude - transform.up * speedLoss * Time.deltaTime;
    }

    public void Boost ()
    {
        if (fuel >= fuelUsedByBoost)
        {
            m_rigidbody.velocity = transform.up * m_rigidbody.velocity.magnitude + transform.up * speedBoost;
            fuel -= fuelUsedByBoost;
            if (FuelLevelChange != null)
            {
                FuelLevelChange.Invoke(fuel);
            }
        }
    }
}
