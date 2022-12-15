using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenLevelSelector()
    {
        SceneManager.LoadScene(1);
    }
    public void StartLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene(4);
    }
    public void StartNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < 4)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(1);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
