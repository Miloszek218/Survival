using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public void ButtonPlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonOptions()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonQuitGame()
    {
        SceneManager.LoadScene(2);
    }
}
