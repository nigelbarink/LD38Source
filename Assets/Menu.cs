using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {


    public void playGame() {
        SceneManager.LoadScene("_level");
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void quit()
    {
        Application.Quit();
    }
}
