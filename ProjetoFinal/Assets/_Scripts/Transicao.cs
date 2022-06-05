using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transicao : MonoBehaviour
{
   public Animator transition;
   public float transitionTime = 1f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            LoadNextScene(1);
        }
        
    }
    public void LoadNextScene(int scene_index){

        StartCoroutine(LoadSceneTransition(SceneManager.GetActiveScene().buildIndex + scene_index));
       
    }

    public IEnumerator LoadSceneTransition(int sceneIndex){
       transition.SetTrigger("Start");

       yield return new WaitForSeconds(transitionTime);

       SceneManager.LoadScene(sceneIndex);
    }
}
