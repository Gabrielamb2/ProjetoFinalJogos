using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetText : MonoBehaviour
{

    public string text_string;
    void Start()
     {
         var parent = transform.parent;
         var parentRenderer = parent.GetComponent<Renderer>();

         var renderer = GetComponent<Renderer>();
         renderer.sortingLayerID = parentRenderer.sortingLayerID;
         renderer.sortingOrder = parentRenderer.sortingOrder+2;
 
         var spriteTransform = parent.transform;
         var text = GetComponent<TextMesh>();
         var pos = spriteTransform.position;
         text.text = string.Format($"{text_string}");
     }
}

// Referência:s
// https://answers.unity.com/questions/620747/render-text-on-sprite-prefab-2d-ios.html