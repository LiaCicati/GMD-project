using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDamage : MonoBehaviour
{
    // HP = Hit points - amount of damage that an object can sustain before it is destroyed or defeated
    public int HP = 40;
    public Animator animator;

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Enemy taking damage: " + damageAmount + " HP = " + HP);
        HP -= damageAmount;
        if (HP <= 0)
        {
            // Play Death Animation
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            // Play Get Hit Animation
            animator.SetTrigger("damage");
        }
    }
    
    //private void OnTriggerEnter(Collider other)
    //{
        //if (other.tag == "Enemy")
        //{
         //   other.GetComponent<EnemyDamage>().TakeDamage(20);
       // }
   // }
/*

public float enemyDamageAmount;
public DateTime nextDamage;
public float damageAfterTime;
public bool enemyInFightRange = false;


public GameObject enemyObj;
void Awake()
{
    nextDamage = DateTime.Now;
}

void FixedUpdate()
{
    if (enemyInFightRange == true)
    {
       DamageEnemy(); 
    }
}

private void OnTriggerEnter(Collider other)
{
    if (other.tag == "Enemy")
    {
        enemyObj = other.gameObject;
        enemyInFightRange = true;
    }
}

private void OnTriggerExit(Collider other)
{
    if (other.tag == "Enemy" )
    {
        enemyInFightRange = false;
    }
}

public void DamageEnemy()
{
    if (nextDamage <= DateTime.Now)
    {
        nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble((damageAfterTime)));
    }
} */
}
