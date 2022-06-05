using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

public class Automatos : MonoBehaviour
{

    public GameObject instructions;  // Texto das instruçõees        
    private GameManager gm;
    public GameObject q0;
    public GameObject q1;
    public GameObject q2;
    public GameObject q3;
    public GameObject q4;

    private int id;

    private List<Tuple<int, int>> drawnPositions = new List<Tuple<int, int>>();

    void Start()
    {
        gm = GameManager.GetInstance();
        Invoke(nameof(Begin), 2.5f);
          
    }

    void Begin() {
        instructions.SetActive(false);  

        if (gm.gameState == GameManager.GameState.GAME && (gm.current_scene == 1)) { 
        GameManager.changeStateDelegate += Construir;
        Construir();
        }
        gm.StartTimer(); 
    }


    void NewGameObject(GameObject GO) {
        int randX = UnityEngine.Random.Range(-4, 4);
        int randY = UnityEngine.Random.Range(-3, 3);

        // para não repetir posições ou sobrepôr as bolhinhas
        while (drawnPositions.Contains(new Tuple<int, int>(randX, randY))){
            randX = UnityEngine.Random.Range(-4, 4);
            randY = UnityEngine.Random.Range(-3, 3);
        }
        
        drawnPositions.Add(new Tuple<int, int>(randX, randY));
        drawnPositions.Add(new Tuple<int, int>(randX-1, randY));
        drawnPositions.Add(new Tuple<int, int>(randX+1, randY));
        drawnPositions.Add(new Tuple<int, int>(randX, randY-1));
        drawnPositions.Add(new Tuple<int, int>(randX, randY+1));
        drawnPositions.Add(new Tuple<int, int>(randX-1, randY-1));
        drawnPositions.Add(new Tuple<int, int>(randX+1, randY-1));
        drawnPositions.Add(new Tuple<int, int>(randX-1, randY+1));
        drawnPositions.Add(new Tuple<int, int>(randX+1, randY+1));
        
        GameObject i = Instantiate(GO, new Vector3(randX, randY, 0), Quaternion.identity);
    }


    void Construir() {
       Debug.Log("Construir");
     if (gm.gameState == GameManager.GameState.GAME && (gm.current_scene == 1)) { 
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        NewGameObject(q0);
        NewGameObject(q1);
        NewGameObject(q2);
        NewGameObject(q3);
        NewGameObject(q4);
    }
    }

}


