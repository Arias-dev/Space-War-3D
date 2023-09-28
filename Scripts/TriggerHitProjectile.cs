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

            /*
            AudioSource audioSource = transform.GetChild(0).GetComponent<AudioSource>();
            if (audioSource != null)
            {
                // Hentikan audio jika ada
                audioSource.Stop();
            }
            */

            StartCoroutine(ReturnObject());
        }
        
    }


    private IEnumerator ReturnObject()
    {
        
        ProjacttilePool.Instance.ReturnProjectileToPool(gameObject);
        yield return null;
    }

}
