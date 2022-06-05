using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Image _timerFill;
    private GameManager gm;
    

    private void Start() {
        gm = GameManager.GetInstance();
        _timerFill = GetComponentInChildren<Image>();
    }

    // private static GameManager _instance;
    // public static GameManager GetInstance() {
    //     if (_instance == null) {
    //         _instance = new GameManager();
    //     }

    //     return _instance;
    // }

    private void Update() {
        gm.RunningTime = (gm.MaxTime - (Time.time - gm.StartTime));
        _timerFill.fillAmount = gm.RunningTime / gm.MaxTime;

        // Debug.Log($"{_timerFill.fillAmount}");
        if (gm.RunningTime < 0) {
            if(gm.vidas <=0  && gm.gameState == GameManager.GameState.GAME) 
                gm.ChangeState(GameManager.GameState.ENDGAME);
            else{
                gm.vidas--;
                gm.game_time_over = true;
            }
            Debug.Log("Time Over");
            Destroy(gameObject);
        }
    }
}

