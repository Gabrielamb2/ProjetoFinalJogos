using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
     // Start is called before the first frame update
    GameManager gm;
    private Transicao transition;

    private void OnEnable(){
        gm = GameManager.GetInstance();
        transition = FindObjectOfType<Transicao>();
    }

    // Update is called once per frame
    public void Retornar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        
    }
    public void Inicio()
    {
        gm.ChangeState(GameManager.GameState.MENU);
        transition.LoadFirstScene();
    }

}
