using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuringMachine : MonoBehaviour
{
    public float velocidade;
    private GameManager gm;
    public GameObject endscreen;

    private Transicao transition;

    void Start()
    {
        velocidade = 6; 
        gm = GameManager.GetInstance();
        transition = FindObjectOfType<Transicao>();
        
    }

    void Update()
    {
        if (!(gm.gameState == GameManager.GameState.GAME)) return;
        
        // if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME){
        //     gm.ChangeState(GameManager.GameState.PAUSE);
        // }

        if (gm.game_time_over){
            gm.game_time_over=false;
            GameLost();
        }


        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (transform.position.y <= -4.5)
            transform.position = new Vector3(transform.position.x, (float)-4.5, transform.position.z);
        else if (transform.position.y >=4.5)
            transform.position = new Vector3(transform.position.x, (float)4.5, transform.position.z);

        transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * velocidade;
        Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
        pos.x = Mathf.Clamp((float)pos.x, (float)0.04, (float)0.96);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

    }

    private void GameLost(){
        gm.q_atual = 0;
        // if (gm.vidas >0) gm.vidas--;
        transition.LoadNextScene(-1);
        Debug.Log("Game Lost!!");
    }

    private void Victory(){
        // gm.q_atual = 0;
        // if (gm.vidas >0) gm.vidas--;
        // else ;
        Invoke(nameof(End), 0.5f);
        Debug.Log("Você ganhou!!");
        
    }

    void End() {
        endscreen.SetActive(true);
        transition.LoadNextScene(1);  
        // LoadSceneTransition(0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
   {
       Debug.Log("Collison");
       if (collision.gameObject.CompareTag("q0"))
       {
          if (gm.q_atual == 0){ 
              gm.q_atual++;
              Destroy(collision.gameObject);
            Debug.Log("Collison q0");
          }
          else GameLost();
       }
       else if (collision.gameObject.CompareTag("q1"))
       {
           if (gm.q_atual == 1){ 
              gm.q_atual++;
              Destroy(collision.gameObject);
              Debug.Log("Collison q1");
          }
           else GameLost();
       }else if (collision.gameObject.CompareTag("q2"))
       {
           if (gm.q_atual == 2){ 
              gm.q_atual++;
              Destroy(collision.gameObject);
              Debug.Log("Collison q2");
          }
           else GameLost();
        
       }else if (collision.gameObject.CompareTag("q3"))
       {
           if (gm.q_atual == 3){ 
              gm.q_atual++;
              Destroy(collision.gameObject);
              Debug.Log("Collison q3");
          }
           else GameLost();
        
       }else if (collision.gameObject.CompareTag("q4"))
       {
           if (gm.q_atual == 4){ 
              gm.q_atual++;
              Destroy(collision.gameObject);
              Debug.Log("Collison q4");
              Victory();
          }
           else GameLost();
        
       }
   }
}
