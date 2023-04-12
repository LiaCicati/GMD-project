using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damageAmount = 20;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject,10);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(transform.GetComponent<Rigidbody>());
        if (other.tag == "Enemy")
        {
            Debug.Log("Sword hit enemy: " + other.name);
            //transform.parent = other.transform;
            other.GetComponent<EnemyDamage>().TakeDamage(damageAmount);
            
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
