using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject FadePanel;

    private void Start()
    {
        if (FadePanel != null)
        {
            FadePanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        StartCoroutine(FadeEffect(SceneManager.GetActiveScene().buildIndex));
        GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>().ResetValues();
    }

    public void NextLevel()
    {
        StartCoroutine(FadeEffect(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator FadeEffect(int SceneToLoad)
    {
        FadePanel.SetActive(true);

        for (int i = 0; i < 100; i++)
        {
            FadePanel.GetComponent<CanvasGroup>().alpha = (float)i * 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        SceneManager.LoadScene(SceneToLoad);
    }
}
