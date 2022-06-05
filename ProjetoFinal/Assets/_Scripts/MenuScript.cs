using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
     // Start is called before the first frame update
    GameManager gm;
    private void OnEnable(){
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    public void Comecar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        
    }

     public void Sair() 
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        
        #endif
        Application.Quit();
    }
}
