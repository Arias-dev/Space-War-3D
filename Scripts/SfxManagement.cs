using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManagement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player_Projectile"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
