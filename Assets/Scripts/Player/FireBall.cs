using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public int damageAmount = 10;

    private void Start()
    {
        Destroy(gameObject, 5);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Destroy(transform.GetComponent<Rigidbody>());
            if (other.tag =="SpikeMinion")
            {
                transform.parent = other.transform;
                other.GetComponent<SpikeMinionDeath>().TakeDamage(damageAmount*2);
                
            }
            else if (other.tag == "GhostMinion")
            {
                transform.parent = other.transform;
                other.GetComponent<GhostMinionDeath>().TakeDamage(damageAmount);

            }
            else if (other.tag == "DistractionMinion")
            {
                transform.parent = other.transform;
                other.GetComponent<DistractionMinionDeath>().TakeDamage(damageAmount/2);

            }
            else if (other.tag == "PartyMinion")
            {
                transform.parent = other.transform;
                other.GetComponent<PartyMinionDeath>().TakeDamage(damageAmount);

            }
            else if (other.tag == "SlimeMinion")
            {
                transform.parent = other.transform;
                other.GetComponent<SlimeMinionDeath>().TakeDamage(damageAmount*2);

            }

        }
        
    }
}
