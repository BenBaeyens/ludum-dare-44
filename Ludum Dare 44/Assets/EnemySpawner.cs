using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemyParent;
    public float time;

    void Start()
    {
        InvokeRepeating("spawnEnemy", 0, time);   
    }

    void spawnEnemy() {
        Instantiate(enemy, transform.position, transform.rotation, enemyParent.transform);
    }

  
}
