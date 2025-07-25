using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSGameManager : Singleton<FPSGameManager>
{
    public enum GameState {  Ready, Run, Pause, GameOver }
    public GameState gState;

    public GameObject gameLabel;
    public GameObject gameOption;
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
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0);

            gameLabel.SetActive(true); 
            gameText.text = "Game Over";
            gameText.color = new Color(255, 0, 0, 255);

            Transform buttons = gameText.transform.GetChild(0);
            buttons.gameObject.SetActive(true); // 버튼 활성화

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

    public void OpenOptionWindow()
    {
        gameOption.SetActive(true); // 옵션 창 활성화
        Time.timeScale = 0f; // 실행 흐름이 멈추기는 하는데, UI는 동작 가능
        gState = GameState.Pause; // 게임 상태를 Pause로 변경
    }

    public void CloseOptionWindow()
    {
        gameOption.SetActive(false); // 옵션 창 비활성화
        Time.timeScale = 1f; // 실행 흐름이 다시 시작
        gState = GameState.Run; // 게임 상태를 Run으로 변경
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // 실행 흐름이 다시 시작
        SceneManager.LoadScene(1); // 현재 씬을 다시 로드하여 게임 재시작
    }

    public void QuitGame()
    {
        Application.Quit(); // 게임 종료
    }
}
