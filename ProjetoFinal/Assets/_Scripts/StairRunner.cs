using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairRunner : MonoBehaviour
{
    public float velocidade;
    public float jumpHeight;
    private bool onGround;
    private Animator anim; 
    private GameManager gm;

    void Start()
    {
        velocidade = 4; 
        gm = GameManager.GetInstance();
        jumpHeight=(float)4;
        onGround = false;
        anim = GetComponent<Animator>();
        Invoke(nameof(Begin), 1.5f);
          
    }

    void Begin() {
        // instructions.SetActive(false);  
        // GameManager.changeStateDelegate += Construir;
        // Construir();
        gm.StartTimer(); 
    }


    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");

        if(Input.GetAxisRaw("Jump") != 0 ){
            transform.position += new Vector3(inputX,(float)jumpHeight , 0) * Time.deltaTime * velocidade;
            anim.SetTrigger("Jump");
        }else {
            transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
        }



        if (inputX != 0)
        {
            anim.SetInteger("Speed", 1);
        }
        else
        {
            anim.SetInteger("Speed", 0);
        }

        // Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
        // pos.x = Mathf.Clamp((float)pos.x, (float)0.04, (float)0.96);
        // transform.position = Camera.main.ViewportToWorldPoint(pos);

    }


    private void GameLost(){
        gm.q_atual = 0;
        if (gm.vidas >0) gm.vidas--;
        // else ;
        // transition.LoadSceneTransition(0);
        Debug.Log("Game Lost!!");
    }

    private void Victory(){
        // gm.q_atual = 0;
        // if (gm.vidas >0) gm.vidas--;
        // else ;
        // Invoke(nameof(End), 0.5f);
        Debug.Log("Você ganhou!!");
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collison");
        if (collision.gameObject.CompareTag("Door"))
        {
            Victory();
        }else if (collision.gameObject.CompareTag("Robot")){
            GameLost();
        }
     
    }  


//     private void OnTriggerEnter2D(Collider2D collision)
//    {
//        Debug.Log("Collison");
//        if (collision.gameObject.CompareTag("q0"))
//        {
//           if (gm.q_atual == 0){ 
//               gm.q_atual++;
//               Destroy(collision.gameObject);
//             Debug.Log("Collison q0");
//           }
//           else GameLost();
//        }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if(collision.gameObject.CompareTag("Robot")){
            GameLost();
        }
            
     } 
    // void OnCollisionExit(Collision collision)
    // {
    //     Debug.Log("collision exit");
    //     if(collision.gameObject.CompareTag("Tilemap")){
    //     onGround = false;
    //     }
            
    // }
 
}
