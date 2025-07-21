using System.Collections;
using TMPro;
using UnityEngine;

public class FPSGameManager : Singleton<FPSGameManager>
{
    public enum GameState {  Ready, Run, GameOver }
    public GameState gState;

    public GameObject gameLabel;
    private TextMeshProUGUI gameText;

    private FPS_PlayerMove player;

    private void Start()
    {
        gState = GameState.Ready;
        gameText = gameLabel.GetComponent<TextMeshProUGUI>();

        gameText.text = "Ready...";
        gameText.color = new Color(255, 185, 0, 255);

        player = GameObject.Find("Player").GetComponent<FPS_PlayerMove>();

        StartCoroutine(ReadyToStart()); // Ready -> Run으로 전환되는 코루틴
    }

    private void Update()
    {
        if (player.hp <= 0)
        {
            gameLabel.SetActive(true); 
            gameText.text = "Game Over";
            gameText.color = new Color(255, 0, 0, 255);
            gState = GameState.GameOver; // 게임 상태를 GameOver로 변경
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);
        gameText.text = "Go!"; // 텍스트 변경

        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false); // 게임 전환을 알려주는 텍스트 종료
        gState = GameState.Run;
    }


}
