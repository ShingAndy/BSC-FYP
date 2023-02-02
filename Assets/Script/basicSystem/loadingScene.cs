using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingScene : MonoBehaviour
{
    public Slider loadingSlider;
    public GameObject loadingUI;

    public void LoadScene(int sceneLevel)
    {
        loadingUI.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneLevel));
    }

    IEnumerator LoadSceneAsync(int sceneLevel)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneLevel);
        while (!operation.isDone)
        {
            if (loadingSlider)
                loadingSlider.value = operation.progress;
            yield return null;
        }
    }
}
