using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscorregadorRunner : MonoBehaviour
{
    public float velocidade;
    public float xVelocidade;
    GameManager gm;
    private Transicao transition;

    private void Start()
    {
        gm = GameManager.GetInstance();
        transition = FindObjectOfType<Transicao>();
        transition.transitionTime = 0.0f;
    }



    // Update is called once per frame
    void FixedUpdate(){
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(xVelocidade, inputY * velocidade, 0) *  Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tunnel")){
            Debug.Log("bateu");
            transition.LoadNextScene(-2);
        }

        else if (collision.CompareTag("Finish")){
             transition.LoadNextScene(1);
        }
    }  
}
