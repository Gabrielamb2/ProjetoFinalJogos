using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlockers : MonoBehaviour{
    public GameObject blocker1;
    public GameObject blocker2;
    public GameObject blocker3;
    public float respawnTime;
    private GameObject randomPrefab;
    private float lastLevelTime = 0.0f;

    void Start(){
        
    }

    private GameObject GenerateRandomEnemy(){
        int randomNumber = Random.Range(0, 3);
        if (randomNumber == 0) return blocker1;
        else if(randomNumber == 1) return blocker2;
        return blocker3;
    }

    private void SpawnBlocker(){
        randomPrefab = GenerateRandomEnemy();
        GameObject a = Instantiate(randomPrefab) as GameObject;
        a.transform.position = new Vector2(-7.91f, -2.91f);
    }

    void Update(){
         if (Time.time - lastLevelTime >= respawnTime){
                lastLevelTime = Time.time;
                respawnTime *= 0.985f;
                SpawnBlocker();
            }
    }
}
