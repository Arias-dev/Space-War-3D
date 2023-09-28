using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectilePool : MonoBehaviour
{
    public float fireInterval;
    public Vector3 fireDirection;

    private float lastFireTime = 0f;

    private Queue<GameObject> projectilePool = new Queue<GameObject>();

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject projectile = Instantiate(ProjectileManager.Instance.enemyProjectilePrefab);
            projectile.SetActive(false);
            projectilePool.Enqueue(projectile);
        }
    }



    public void FireProjectile()
    {
        float timeSinceLastFire = Time.time - lastFireTime;

        if (timeSinceLastFire >= fireInterval)
        {
            lastFireTime = Time.time;

            if (projectilePool.Count > 0)
            {
                GameObject projectile = projectilePool.Dequeue();
                projectile.transform.position = transform.position;
                projectile.transform.rotation = Quaternion.LookRotation(fireDirection);
                projectile.SetActive(true);

                StartCoroutine(DestroyProjectile(projectile));
            }
        }
    }

    IEnumerator DestroyProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(2f);
        ReturnProjectileToPool(projectile);
    }

    void ReturnProjectileToPool(GameObject projectile)
    {
        projectile.SetActive(false);
        projectilePool.Enqueue(projectile);
    }
}
