using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {

        if (hit.gameObject.CompareTag("Player"))
        {

            EntityData enemyData = hit.GetComponent<EntityData>();
            if (enemyData != null)
            {
                // Pastikan ada komponen EntityData pada musuh
                enemyData.DecreaseHealthPoints(GameObject.FindGameObjectWithTag("Enemy").GetComponent<EntityData>().Attack);
            }



            StartCoroutine(ReturnObject());
        }

    }


    private IEnumerator ReturnObject()
    {

        ProjacttilePool.Instance.ReturnProjectileToPool(gameObject);
        yield return new WaitForSeconds(0.15f);
    }
}
