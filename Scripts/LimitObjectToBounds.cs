using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitObjectToBounds : MonoBehaviour
{
    private Camera mainCamera;
    private Renderer objectRenderer;

    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        mainCamera = Camera.main;
        objectRenderer = GetComponent<Renderer>();

        // Mengambil lebar dan tinggi dari objek
        objectWidth = objectRenderer.bounds.size.x;
        objectHeight = objectRenderer.bounds.size.y;
    }

    void LateUpdate()
    {
        // Mendapatkan batas-batas kamera dalam dunia (world space)
        float cameraLeft = mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect;
        float cameraRight = mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect;
        float cameraTop = mainCamera.transform.position.y + mainCamera.orthographicSize;
        float cameraBottom = mainCamera.transform.position.y - mainCamera.orthographicSize;

        // Mendapatkan posisi objek
        Vector3 objectPosition = transform.position;

        // Memastikan objek tidak melewati batas-batas kamera
        objectPosition.x = Mathf.Clamp(objectPosition.x, cameraLeft + objectWidth / 2, cameraRight - objectWidth / 2);
        objectPosition.y = Mathf.Clamp(objectPosition.y, cameraBottom + objectHeight / 2, cameraTop - objectHeight / 2);

        // Mengatur kembali posisi objek
        transform.position = objectPosition;
    }
}
