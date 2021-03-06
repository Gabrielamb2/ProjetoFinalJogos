using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;


public class GameManager
{
   public enum GameState { MENU, GAME, PAUSE, ENDGAME };
   public GameState gameState { get; private set; }
  
   public bool pause_to_menu = false;
   private static GameManager _instance;

   public bool waspaused = false;

   public bool victory = false;

   private readonly Canvas _countdownUI;

   public int q_atual = 0;

   public bool game_time_over = false;

    public float RunningTime;
    public float MaxTime=12.0f;

    public int current_scene = 0;

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
        gameState = GameState.MENU;
        q_atual = 0;
        game_time_over = false;
        victory = false;

    }
   private GameManager()
   {
        _countdownUI = Resources.Load<Canvas>("countdownUI");
       gameState = GameState.MENU;
       q_atual = 0;
       game_time_over = false;
       victory = false;

       
   }

    public void StartTimer() {
        StartTime = Time.time;
        Object.Instantiate(_countdownUI);
    }
}


