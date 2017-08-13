using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour {

    [SerializeField]
    Transform target;
    [SerializeField]
    float smoothing = 5f;

    void Start()
    {
        Vector3 targetPos = target.position;
        targetPos.z = transform.position.z;
        transform.position = targetPos;
    }

    void FixedUpdate () {
        Vector3 targetPos = target.position;
        targetPos.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.fixedDeltaTime);
	}
}
