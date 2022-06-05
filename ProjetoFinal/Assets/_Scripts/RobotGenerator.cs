using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGenerator : MonoBehaviour
{
    public GameObject robot;
    public float respawnTime;
    private GameObject randomPrefab;
    private float lastLevelTime = 0.0f;

    void Start()
    {
        respawnTime=3;
    }


    private void SpawnBlocker(){
       
        GameObject a = Instantiate(robot) as GameObject;
        a.transform.position = new Vector2(30.6f, 13.3f);
    }

    void Update(){
         if (Time.time - lastLevelTime >= respawnTime){
                lastLevelTime = Time.time;
                SpawnBlocker();
            }
    }
}
