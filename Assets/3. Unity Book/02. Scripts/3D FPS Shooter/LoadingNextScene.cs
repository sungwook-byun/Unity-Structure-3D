using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingNextScene : MonoBehaviour
{
    public int sceneNumber = 2;
    public Slider loadingSlider;
    public TextMeshProUGUI loadingText;

    private void Start()
    {
        StartCoroutine(TransitionNextScene(sceneNumber));
    }


    IEnumerator TransitionNextScene(int num)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(num);
        ao.allowSceneActivation = false; // 로드가 완료되더라도 자동으로 전환하지 않음 (전환방지)

        while (!ao.isDone)
        {
            loadingSlider.value = ao.progress;
            loadingText.text = $"{ao.progress * 100f}%";

            if (ao.progress >= 0.9f) // 로드가 거의 완료되면
                ao.allowSceneActivation = true; // 자동으로 전환 허용

            yield return null; // 다음 프레임까지 대기

        }
    }
}
