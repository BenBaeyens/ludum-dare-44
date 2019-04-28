using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour {

    public TextMeshProUGUI highscore;

    private void Start() {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();
    }


    public void Play() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit() {
        Application.Quit();
    }


}
