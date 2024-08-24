using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public int damageAmount = 20;

    private void Start()
    {
        Destroy(gameObject, 5);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Debug.Log(other.name);
            Destroy(transform.GetComponent<Rigidbody>());
            if (other.tag =="Minion")
            {
                transform.parent = other.transform;
                other.GetComponent<MinionDeath>().TakeDamage(damageAmount);
                
            }

        }
        
    }
}
