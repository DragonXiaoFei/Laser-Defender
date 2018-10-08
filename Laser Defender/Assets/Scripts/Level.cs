using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    [SerializeField] float delayInSeconds = 0.5f;

	public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {

        StartCoroutine(DelayLoading());
    }

    IEnumerator DelayLoading()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

  
}
