using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscorregadorRunner : MonoBehaviour
{
    public float velocidade;
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
        transform.position += new Vector3(1.3f, inputY, 0) *  Time.deltaTime * velocidade;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tunnel")){
            Debug.Log("bateu");
            transition.LoadNextScene(0);
        }
    }  
}
