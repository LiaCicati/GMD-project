using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 20;
    void Start()
    {
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(transform.GetComponent<Rigidbody>());
        if (other.tag == "Enemy")
        {
            Debug.Log("Bullet hit enemy: " + other.name);
            transform.parent = other.transform;
            other.GetComponent<Enemy>().TakeDamage(damageAmount);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}