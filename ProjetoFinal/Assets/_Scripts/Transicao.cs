using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transicao : MonoBehaviour
{
   public Animator transition;
   public float transitionTime = 1f;
   private GameManager gm;

    void Start(){
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && gm.gameState == GameManager.GameState.GAME){
            LoadNextScene(1);
        }
        
    }
    public void LoadNextScene(int scene_index){
        gm.current_scene = SceneManager.GetActiveScene().buildIndex + scene_index;
        StartCoroutine(LoadSceneTransition(SceneManager.GetActiveScene().buildIndex + scene_index));
       
    }

    public void LoadFirstScene(){
        gm.current_scene = 0;
        StartCoroutine(LoadSceneTransition(0));
       
    }

    public IEnumerator LoadSceneTransition(int sceneIndex){
       transition.SetTrigger("Start");

       yield return new WaitForSeconds(transitionTime);

       SceneManager.LoadScene(sceneIndex);
    }
}
