using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Player")
        {
            if (other.gameObject.GetComponent<PlayerController>().gameObject.transform.localScale.x > other.gameObject.GetComponent<PlayerController>().maxSize)
            {
                other.gameObject.GetComponent<PlayerController>().Heal();
            } else
            {
                other.gameObject.GetComponent<PlayerController>().Heal();
                 Destroy(gameObject);
            }

        }
    }

   
}
