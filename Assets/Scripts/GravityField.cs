using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour {
    
    public float maxVelocity = 25.6f;
    public float speedBoost = 7;
    public float speedToEscapeGravity = 15.36f;

    public void Initialize(float maxVelocity, float speedBoost, float speedToEscapeGravity)
    {
        this.maxVelocity = maxVelocity;
        this.speedBoost = speedBoost;
        this.speedToEscapeGravity = speedToEscapeGravity;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null)
        {
            float speedModificator = 0;
            if (collision.attachedRigidbody.velocity.magnitude < maxVelocity / Vector2.Distance(transform.position, collision.transform.position))
            {
                collision.attachedRigidbody.velocity = collision.transform.up * collision.attachedRigidbody.velocity.magnitude + collision.transform.up * speedBoost * Time.deltaTime;
            }
            else
            {
                speedModificator = Mathf.Min(speedToEscapeGravity, collision.attachedRigidbody.velocity.magnitude - maxVelocity / Vector2.Distance(transform.position, collision.transform.position));
                collision.attachedRigidbody.velocity = collision.transform.up * collision.attachedRigidbody.velocity.magnitude;
            }
            collision.transform.up = Vector2.Lerp(collision.transform.up, CalculateOrbit(transform.position, collision.transform), Time.deltaTime * (speedToEscapeGravity - speedModificator) * 100);
        }
    }

    private Vector2 CalculateOrbit (Vector2 planetPos, Transform satellite)
    {
        Vector2 planetDirection = (planetPos - (Vector2)satellite.position).normalized;
        Vector2 satelliteDirection = Quaternion.AngleAxis(90, Vector3.forward) * planetDirection;
        if (Vector2.Angle(satelliteDirection, satellite.up) > Vector2.Angle(-satelliteDirection, satellite.up))
        {
            satelliteDirection *= -1;
        }
        return satelliteDirection;
    }
}
