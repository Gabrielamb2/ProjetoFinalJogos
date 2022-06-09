using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRunner : MonoBehaviour{
    public Rigidbody2D rb;
    public float velocidade;
    public float jumpHeight;
    private bool onGround;
    private Animator anim; 
    private GameManager gm;
    private Transicao transition;


    void Start(){
        gm = GameManager.GetInstance();
        onGround = false;
        anim = GetComponent<Animator>();
        Invoke(nameof(Begin), 1.5f);
        transition = FindObjectOfType<Transicao>();  
    }

    void Begin() {
        gm.StartTimer(); 
    }

    void Update(){
        if (!(gm.gameState == GameManager.GameState.GAME)) {
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME){
            gm.ChangeState(GameManager.GameState.PAUSE);
        }

        if (gm.game_time_over){
            gm.game_time_over=false;
            GameLost();
        }

        float inputX = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= -2.91)
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        else transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;

        if (inputX != 0) anim.SetInteger("Velocity", 1);
        else anim.SetInteger("Velocity", 0);

    }

    private void GameLost(){
        gm.q_atual = 0;
        transition.LoadNextScene(-1);
        Debug.Log("Game Lost!!");
    }

    private void Victory(){
        transition.LoadNextScene(1);
        Debug.Log("Você ganhou!!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("P1"))
        {
            transition.LoadNextScene(1);
        }

     
    } 
}
