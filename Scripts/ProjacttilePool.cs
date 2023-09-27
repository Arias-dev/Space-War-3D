using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjacttilePool : MonoBehaviour
{
    public static ProjacttilePool Instance { get; private set; }

    public GameObject projectilePrefab;
    public Transform parentPrefab;
    public int poolSize;
    public float maxRange;


   // public float Interval;

    private Queue<GameObject> projectilePool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this; // Inisialisasi singleton instance

        InitializePool();
    }

    void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectilePool.Enqueue(projectile);
        }
    }


    public void Fires()
    {
        StartCoroutine(FireProjectile(parentPrefab.transform.position, parentPrefab.transform.rotation));
    }

    
    public IEnumerator FireProjectile(Vector3 position, Quaternion rotation)
    {
        if (projectilePool.Count > 0)
        {
            yield return new WaitForSeconds(0.1f);

            GameObject projectile = projectilePool.Dequeue();
            projectile.transform.position = position;
            projectile.transform.rotation = rotation;
            projectile.SetActive(true);

            StartCoroutine(DestroyProjectile(projectile)); // Memulai coroutine untuk menghancurkan proyektil
        }
    }
    
    private IEnumerator DestroyProjectile(GameObject projectile)
    {
        yield return new WaitUntil(() => Vector3.Distance(projectile.transform.position, parentPrefab.position) > maxRange);
        ReturnProjectileToPool(projectile);
    }


    public void ReturnProjectileToPool(GameObject projectile)
    {
        projectile.SetActive(false);
        projectilePool.Enqueue(projectile);
    }
}
