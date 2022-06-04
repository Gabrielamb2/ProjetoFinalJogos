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

    void Start(){
        gm = GameManager.GetInstance();
        onGround = false;
        anim = GetComponent<Animator>();
        Invoke(nameof(Begin), 1.5f);
        
        
    }

    void Begin() {
        gm.StartTimer(); 
    }

    void Update(){
        float inputX = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= -2.91)
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        else transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;

        if (inputX != 0) anim.SetInteger("Speed", 1);
        else anim.SetInteger("Speed", 0);

    }

    private void GameLost(){
        gm.q_atual = 0;
        if (gm.vidas >0) gm.vidas--;
        Debug.Log("Game Lost!!");
    }

    private void Victory(){
        Debug.Log("Você ganhou!!");
    }
}
