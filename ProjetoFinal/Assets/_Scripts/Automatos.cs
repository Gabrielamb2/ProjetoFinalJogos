using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

public class Automatos : MonoBehaviour
{

    public GameObject instructions;  // Textou das instruçõees        public float velocidade;
    // private Animator anim;
    private GameManager gm;

    public GameObject q0;
    public GameObject q1;
    public GameObject q2;
    public GameObject q3;
    public GameObject q4;

    private List<Tuple<int, int>> drawnPositions = new List<Tuple<int, int>>();

    void Start()
    {
        gm = GameManager.GetInstance();
        Invoke(nameof(Begin), 2.5f);
          
    }

    void Begin() {
        instructions.SetActive(false);  
        GameManager.changeStateDelegate += Construir;
        Construir();
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
       Debug.Log($"waspaused{gm.waspaused} | {gm.gameState} | {gm.gameState== GameManager.GameState.GAME}");
    //    if (gm.gameState == GameManager.GameState.GAME && !(gm.waspaused)) { 
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        NewGameObject(q0);
        NewGameObject(q1);
        NewGameObject(q2);
        NewGameObject(q3);
        NewGameObject(q4);
    //    }
    }


    void Update()
     {
         if (Input.GetMouseButtonDown(0))
         {
            //  Debug.Log("Mouse");
             
            // RaycastHit raycastHit;
            //  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //  if (Physics.Raycast(ray, out raycastHit, 100f))
            //  {
            //      Debug.Log("oii");
            //      if (raycastHit.transform != null)
            //      {
            //         //Our custom method. 
            //          CurrentClickedGameObject(raycastHit.transform.gameObject);
            //      }
            //  }

            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            Debug.Log("Mouse");
 
            if (Physics.Raycast (ray, out hit, 100)) {
                Debug.Log ("hit.transform.gameObject.name");
                Debug.Log (hit.transform.gameObject.name);
            }
         }
     }


      public void CurrentClickedGameObject(GameObject gameObject)
        {
            Debug.Log($"CurrentClickedGameObject");
            if(gameObject.tag=="q1")
            {
                Debug.Log($"{gameObject.tag}");
            }
        }
}


