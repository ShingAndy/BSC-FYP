using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class loadingScene : MonoBehaviour
{
    public Slider loadingSlider;

    public void LoadScene(int sceneLevel)
    {
        StartCoroutine(LoadSceneAsync(sceneLevel));
    }

    IEnumerator LoadSceneAsync(int sceneLevel)
    {
        AsyncOperation operation = EditorSceneManager.LoadSceneAsync(sceneLevel);
        while (!operation.isDone)
        {
            if (loadingSlider)
                loadingSlider.value = operation.progress;
            yield return null;
        }
    }
}
