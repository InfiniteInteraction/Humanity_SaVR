using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class EnemyC : MonoBehaviour
//{
//    private ESpawner roundManager;
//    private Spawners enemyManager;
//    private float timerValue = 1.5f;

//    private void Start()
//    {
//        enemyManager = GameObject.Find("Spawner").GetComponent<Spawners>();
//    }
//    public void Init(ESpawner _roundmanager)
//    {
//        roundManager = _roundmanager;
//    }



//    private void Update()
//    {
//        timerValue -= Time.deltaTime;
//        if (timerValue <= 0f)
//        {
//            Death();
//        }
//    }

//    private void Death()
//    {
//        roundManager.RemoveEnemy();
//        enemyManager.killCount++;
//        enemyManager.SpawnGreen();
//        Destroy(gameObject);

//    }
//}
