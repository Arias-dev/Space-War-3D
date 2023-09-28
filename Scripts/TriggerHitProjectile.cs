using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHitProjectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<EntityData>().DecreaseHealthPoints(GameObject.FindGameObjectWithTag("Player").GetComponent<EntityData>().Attack);

        }
    }
}
