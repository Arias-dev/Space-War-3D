using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPointUI : MonoBehaviour
{
    public GameObject Target;


    private void Update()
    {

        if (Target.gameObject.activeInHierarchy)
        {
            GetComponent<Image>().fillAmount = Target.GetComponent<EntityData>().CurrentHp/ Target.GetComponent<EntityData>().MaxHp;
        }
            

       
    }




}
