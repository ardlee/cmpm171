using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadeOutUIGroup;
    public float fadeDuration = 1f; 

    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        yield return StartCoroutine(FadeToBlack());

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeToBlack()
    {
        fadeOutUIGroup.blocksRaycasts = true;

        float fadeSpeed = 1f / fadeDuration;
        while (fadeOutUIGroup.alpha < 1)
        {
            fadeOutUIGroup.alpha += fadeSpeed * Time.deltaTime;
            yield return null;
        }

        fadeOutUIGroup.alpha = 1;
    }
}
