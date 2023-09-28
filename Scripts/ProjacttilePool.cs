using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjacttilePool : MonoBehaviour
{
    public static ProjacttilePool Instance { get; private set; }

    public GameObject projectilePrefab;
    

    public int poolSize;
    public float maxRange;

    public float fireInterval;
    private float lastFireTime = 0f;

    private Queue<GameObject> projectilePool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;

        InitializePool();
    }

    void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            
            GameObject projectile = Instantiate(projectilePrefab);

            if (projectile.gameObject.tag.Equals("Player_Projectile"))
            {
                projectile.SetActive(false);
                projectilePool.Enqueue(projectile);
            }
        }
    }

    public void FireProjectile(Vector3 position, Quaternion rotation)
    {
        
        
        float timeSinceLastFire = Time.time - lastFireTime;

        if (timeSinceLastFire >= fireInterval)
        {
            lastFireTime = Time.time;

            if (projectilePool.Count > 0)
            {
                GameObject projectile = projectilePool.Dequeue();

                
                    projectile.transform.position = position;
                    projectile.transform.rotation = rotation;
                    projectile.SetActive(true);

                    StartCoroutine(DestroyProjectile(projectile));
                

                
            }
        }
    }

    private IEnumerator DestroyProjectile(GameObject projectile)
    {
        yield return new WaitUntil(() => Vector3.Distance(projectile.transform.position, transform.position) > maxRange);
        ReturnProjectileToPool(projectile);
    }

    public void ReturnProjectileToPool(GameObject projectile)
    {
        projectile.SetActive(false);
        projectilePool.Enqueue(projectile);
    }
}
