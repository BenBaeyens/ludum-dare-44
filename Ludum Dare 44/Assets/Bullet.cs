using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour { 
    

    Vector3 PlayerDir;


    public GameObject player;

    public float moveSpeed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveBullet();
        }
    }

    void MoveBullet() {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
        PlayerDir = player.transform.forward;
        GetComponent<Rigidbody>().velocity = PlayerDir * moveSpeed;
    }
}
