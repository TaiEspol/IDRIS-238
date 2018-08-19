using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Cone : MonoBehaviour {

    public finalEnemy turret;
    public bool isLeft = false;

    void Awake()
    {
        turret = gameObject.GetComponentInParent<finalEnemy>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isLeft)
            {
                turret.Attack(false);
            }
            else
            {
                turret.Attack(true);
            }
        }
    }
}
