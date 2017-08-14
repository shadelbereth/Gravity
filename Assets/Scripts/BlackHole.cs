using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHole : MonoBehaviour {

    [SerializeField]
    string nextLevel = "Win";

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null)
        {
            if (Vector2.Distance(transform.position, collision.transform.position) < collision.transform.lossyScale.magnitude)
            {
                SceneManager.LoadScene(nextLevel);
            }
            collision.transform.up = Vector2.Lerp(collision.transform.up, CalculateSuction(transform.position, collision.transform), Time.deltaTime * 100);
        }
    }

    private Vector2 CalculateSuction (Vector2 blackHolePos, Transform suckedObject)
    {
        Vector2 blackHoleDirection = (blackHolePos - (Vector2)suckedObject.position).normalized;
        Vector2 trajectory = Quaternion.AngleAxis(30, Vector3.forward) * blackHoleDirection;
        if (Vector2.Angle(trajectory, suckedObject.up) > Vector2.Angle(-trajectory, suckedObject.up))
        {
            trajectory *= -1;
        }
        return trajectory;
    }
}
