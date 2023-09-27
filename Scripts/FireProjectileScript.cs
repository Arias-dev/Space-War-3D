using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireProjectileScript : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction fireProjectile;
    public float fireInterval;
    bool isFiring = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        fireProjectile = playerInput.actions.FindAction("Fires");
        fireProjectile.started += OnFireStarted;
        fireProjectile.canceled += OnFireCanceled;
    }

    private void Update()
    {
        if (isFiring)
        {
            fires();
        }
    }

    private void fires()
    {
        ProjacttilePool.Instance.FireProjectile(ProjacttilePool.Instance.parentPrefab.transform.position, ProjacttilePool.Instance.parentPrefab.transform.rotation);
    }

    private void OnFireStarted(InputAction.CallbackContext context)
    {
        isFiring = true;
        StartCoroutine(FireProjectilesRoutine());
    }

    private void OnFireCanceled(InputAction.CallbackContext context)
    {
        isFiring = false;
    }

    private IEnumerator FireProjectilesRoutine()
    {
        while (isFiring)
        {
            
            yield return new WaitForSeconds(fireInterval);
            fires();
        }
    }
}
