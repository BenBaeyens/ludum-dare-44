using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour { 
    

    Vector3 PlayerDir;


    public GameObject player;

    public float moveSpeed = 12f;


    private void Start() {

        player = GameObject.Find("Player");
        MoveBullet();
    }


    private void OnTriggerEnter(Collider other) {
        if (other.name.Contains("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
      
    }

    void MoveBullet() {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
        PlayerDir = player.transform.forward;
        GetComponent<Rigidbody>().velocity = PlayerDir * moveSpeed;
        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet() {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
