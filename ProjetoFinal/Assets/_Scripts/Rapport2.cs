using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rapport2 : MonoBehaviour
{
     // Start is called before the first frame update
    // GameManager gm;
    private int contagem = 0;
    private Transicao transition;
    private void Start(){
       transition = FindObjectOfType<Transicao>();
    }

    // Update is called once per frame
    public void op1()
    {
        Debug.Log("2");
        transition.LoadNextScene(-1);
        
    }

     public void op2()
    {
        Debug.Log("3");
        transition.LoadNextScene(-1);
        
        
    }
    public void op3()
    {
        Debug.Log("1");
        transition.LoadNextScene(1);
        
        
    }
}
