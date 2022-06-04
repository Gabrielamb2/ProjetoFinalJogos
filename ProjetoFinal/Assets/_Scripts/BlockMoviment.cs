using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoviment : MonoBehaviour{
    public float velocity;

    void Update(){
        transform.position += new Vector3(1, 0 , 0) * Time.deltaTime * velocity;
    }
}
