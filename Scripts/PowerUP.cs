using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    // Delegate untuk notifikasi perubahan interval tembakan
    public delegate void OnPowerUpCollected(float newFireInterval);
    public static event OnPowerUpCollected PowerUpCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Memanggil event untuk memberitahu sistem tembakan
            if (PowerUpCollected != null)
            {
                // Kurangi nilai fireInterval sebanyak 0.1f (atau sesuai dengan kebutuhan)
                PowerUpCollected(ProjacttilePool.Instance.fireInterval - 0.1f);
            }

            // Hapus objek power-up setelah dikumpulkan
            Destroy(gameObject);
        }
    }
}
