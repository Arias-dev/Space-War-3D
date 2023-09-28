using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objek yang ingin diikuti

    public float smoothSpeed = 0.125f; // Seberapa "halus" kamera mengikuti objek

    public Vector3 offset; // Jarak antara kamera dan objek

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target); // Fokus kamera pada objek
    }
}
