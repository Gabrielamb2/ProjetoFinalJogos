using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Police : MonoBehaviour
{
    private Animator anim;   
    // GameManager gm;
    private SpriteRenderer mySpriteRenderer;
    public float inputY;
    float x_player;
    private void Start()
    {
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
        // gm = GameManager.GetInstance();
    }



    void FixedUpdate()
    {
        // if (gm.gameState != GameManager.GameState.GAME) return;

        float inputX = Input.GetAxis("Horizontal");
        if(inputX < 0){ //para tras
            mySpriteRenderer.flipX = true;
        }else if(inputX > 0){
            mySpriteRenderer.flipX = false;
        }

        x_player = GameObject.Find("Player").transform.position.x - inputX;
        Vector3 tmpPosition = transform.position;
        tmpPosition.x = x_player;
        transform.position = tmpPosition;

        Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
        pos.x = Mathf.Clamp((float)pos.x, (float)0.04, (float)0.96);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        float screen_size=4.0f;
        if (transform.position.y <= -screen_size)
            transform.position = new Vector3(transform.position.x, -screen_size, transform.position.z);

        Debug.Log(inputX);
        if ( inputX != 0)
        {
            anim.SetFloat("Velocity", 1.0f);
            Debug.Log("Walking\n");
        }
        else
        {
            anim.SetFloat("Velocity", 0.0f);
            Debug.Log("Idle\n");
        }

       
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
    //     if (collision.CompareTag("Escorregador") || (collision.CompareTag("Elevador"))
    //     {
        
    //     }

     
    // }  

}
