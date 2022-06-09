using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscorregadorRunner : MonoBehaviour
{
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        float inputY = Input.GetAxis("Vertical");
        print(inputY);
        transform.position += new Vector3(0, inputY, 0) * velocidade;
        print(transform.position);
    }
}
