using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;   
    // GameManager gm;
    public float velocidade;

    private void Start()
    {
        anim = GetComponent<Animator>();
        velocidade = 6;  
        // gm = GameManager.GetInstance();
    }



    void FixedUpdate()
    {
        // if (gm.gameState != GameManager.GameState.GAME) return;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * velocidade;

        Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
        pos.x = Mathf.Clamp((float)pos.x, (float)0.04, (float)0.96);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        // if (yInput != 0 || xInput != 0)
        // {
        //     anim.SetFloat("Velocity", 1.0f);
        // }
        // else
        // {
        //     anim.SetFloat("Velocity", 0.0f);
        // }

       
    //    if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
    //         gm.ChangeState(GameManager.GameState.PAUSE);
    //     }

        // if(gm.timeRemainig <=0  && gm.gameState == GameManager.GameState.GAME) {
        //     gm.ChangeState(GameManager.GameState.ENDGAME);
        //     Reset();
        // }

    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Inimigos"))
    //     {
        
    //     }

    //     else if (collision.CompareTag("Nave"))
    //     {
           
    //     }

     
    // }  

}
