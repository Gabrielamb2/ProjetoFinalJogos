using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;   
    GameManager gm;
    private float velocidade;
    private SpriteRenderer mySpriteRenderer;
    private Transicao transition;

    private void Start()
    {
        anim = GetComponent<Animator>();
        velocidade = 2;  
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        gm = GameManager.GetInstance();
        transition = FindObjectOfType<Transicao>();
        transition.transitionTime = 0.5f;

    }

    void Update(){
         if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME){
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }

    void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if(inputX < 0){
            mySpriteRenderer.flipX = true;
        }else if(inputX > 0){
            mySpriteRenderer.flipX = false;
        }
        transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * velocidade;

        Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
        pos.x = Mathf.Clamp((float)pos.x, (float)0.04, (float)0.96);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        float screen_size=4.0f;
        if (transform.position.y <= -screen_size)
            transform.position = new Vector3(transform.position.x, -screen_size, transform.position.z);

        
        if (inputY != 0 || inputX != 0)
        {
            anim.SetFloat("Velocity", 1.0f);
            // Debug.Log("Walking\n");
        }
        else
        {
            anim.SetFloat("Velocity", 0.0f);
            // Debug.Log("Idle\n");
        }

       
    //    if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
    //         gm.ChangeState(GameManager.GameState.PAUSE);
    //     }

        // if(gm.timeRemainig <=0  && gm.gameState == GameManager.GameState.GAME) {
        //     gm.ChangeState(GameManager.GameState.ENDGAME);
        //     Reset();
        // }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Elevador") || collision.CompareTag("Cancela"))
        {
            Debug.Log("bateu");
            transition.LoadNextScene(1);
        }

        else if ( collision.CompareTag("Escorregador") ){
            transition.LoadNextScene(2);
        }

        else if (collision.CompareTag("Almoco"))
        {
            if (gm.gameState == GameManager.GameState.GAME){
                gm.victory=true;
                gm.ChangeState(GameManager.GameState.ENDGAME);
            }
        }

     
    }  

}
