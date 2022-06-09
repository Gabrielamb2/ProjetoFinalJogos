
using UnityEngine;
using UnityEngine.UI;
public class UI_FimDeJogo : MonoBehaviour
{
    public Text message;
    GameManager gm;
    private Transicao transition;

    
    void Start(){
        transition = FindObjectOfType<Transicao>();
    }
 
     public void Voltar()
    {
        transition.LoadFirstScene();
        gm.ChangeState(GameManager.GameState.GAME);
        
    }

    public void Sair() 
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        
        #endif
        Application.Quit();
    }


    private void OnEnable()
    {
        
        float minutes, seconds;
        string text;
        gm = GameManager.GetInstance();

        if(gm.victory){
           message.text = "Você Ganhou!!";
       } 
       else{
            // AudioManager.PlaySFX(perdeuSFX);
            message.text = "Você Perdeu!!";
       } 
    
    }

   
   
}