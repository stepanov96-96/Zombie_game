using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    //public GameObject pauseMenuUI;

    //переход на другую сцену
    public void LoadScene(int Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
