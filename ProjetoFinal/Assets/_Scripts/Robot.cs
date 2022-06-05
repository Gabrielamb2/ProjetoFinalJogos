using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
     public float velocidade;
    private GameManager gm;

    void Start()
    {
        velocidade = 3; 
        gm = GameManager.GetInstance();
        Destroy(gameObject, 8);
        
    }

    void Update()
    {
        transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * velocidade;

    }
}
