using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketMove : MonoBehaviour {

    Rigidbody2D m_rigidbody;
    [SerializeField]
    float initialSpeed = 20;
    [SerializeField]
    float speedLoss = 1;
    [SerializeField]
    float fuel = 90;
    [SerializeField]
    float speedBoost = 15;
    [SerializeField]
    float lateralSpeedBoost = 5;
    [SerializeField]
    float fuelUsedByBoost = 10;
    [SerializeField]
    float fuelUsedByLateralBoost = 2;
    [SerializeField]
    string lostScene = "Lost";

    float lastVelocityMagnitude = 0;

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
        if (fuel == 0)
        {
            if (Mathf.Abs(m_rigidbody.velocity.magnitude - lastVelocityMagnitude) < 0.01 * Time.deltaTime)
            {
                SceneManager.LoadScene(lostScene);
            }
            lastVelocityMagnitude = m_rigidbody.velocity.magnitude;
        }
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

    public void LateralBoost (float angle)
    {
        if (fuel >= fuelUsedByLateralBoost)
        {
            transform.up = Quaternion.AngleAxis(angle, Vector3.forward) * transform.up;
            m_rigidbody.velocity = transform.up * m_rigidbody.velocity.magnitude + transform.up * lateralSpeedBoost;
            fuel -= fuelUsedByLateralBoost;
            if (FuelLevelChange != null)
            {
                FuelLevelChange.Invoke(fuel);
            }
        }
    }
}
