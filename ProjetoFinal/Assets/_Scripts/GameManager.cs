using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;


public class GameManager
{
   public enum GameState { MENU, GAME, PAUSE, ENDGAME };
   public GameState gameState { get; private set; }
   public int vidas;
  
   public bool pause_to_menu = false;
   private static GameManager _instance;

   public bool waspaused = false;

   private readonly Canvas _countdownUI;

   public int q_atual = 0;

    public float RunningTime;
    public float MaxTime=12.0f;

    private float _startTime;
    public float StartTime {
        get => _startTime;
        private set => _startTime = value;
    }


   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

   public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
    if (nextState == GameState.GAME && (gameState != GameState.PAUSE )) Reset();

    else if (nextState == GameState.GAME && (gameState == GameState.PAUSE )) 
        waspaused = true;

    else if (nextState == GameState.MENU && (gameState == GameState.PAUSE ))
        pause_to_menu = true;

    gameState = nextState;
    changeStateDelegate();
    }

    private void Reset()
    {
        vidas = 3;
        q_atual = 0;
    }
   private GameManager()
   {
        _countdownUI = Resources.Load<Canvas>("countdownUI");
       vidas = 3;
       gameState = GameState.MENU;
       q_atual = 0;
       
   }

    public void StartTimer() {
        StartTime = Time.time;
        Object.Instantiate(_countdownUI);
    }
}


