using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData : MonoBehaviour
{

    public static EntityData Instance { get; private set; }

    public float MaxHp;
    public float CurrentHp;
    public float Attack;
    public float Defense;

    private void Awake()
    {
        CurrentHp = MaxHp;
    }
    public void DecreaseHealthPoints(float damage)
    {
        if(CurrentHp > 0)
        {
            CurrentHp = Mathf.Clamp(CurrentHp-(damage-Defense), 0, MaxHp);
        }
        if(CurrentHp <= 0)
        {
            StartCoroutine(DestroyObject());
        }

        Debug.Log("Current HP   :" + CurrentHp);
    }


    private IEnumerator DestroyObject()
    {
        gameObject.SetActive(false);
        //ProjacttilePool.Instance.ReturnProjectileToPool(gameObject);
        yield return null; 
    }

}
