using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager Instance { get; private set; }

    public GameObject enemyProjectilePrefab;

    void Awake()
    {
        Instance = this;
    }
}
