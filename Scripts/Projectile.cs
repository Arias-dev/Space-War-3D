using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    //public float maxRange;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

        // Cek jika proyektil sudah melebihi jarak tertentu
        //if (transform.position.z >= maxRange)
        //{
            // Mengembalikan proyektil ke Pool
            //ProjacttilePool.Instance.ReturnProjectileToPool(gameObject);
        //}
    }
}
