using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerHitProjectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {

        if (hit.gameObject.CompareTag("Enemy"))
        {

            EntityData enemyData = hit.GetComponent<EntityData>();
            if (enemyData != null)
            {
                // Pastikan ada komponen EntityData pada musuh
                enemyData.DecreaseHealthPoints(GameObject.FindGameObjectWithTag("Player").GetComponent<EntityData>().Attack);
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
