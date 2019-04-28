using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour {

    public AudioClip hoversound;
    public AudioClip clicksound;

    AudioSource audioSource;

    public TextMeshProUGUI highscore;

    private void Start() {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    public void Play() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit() {
        Application.Quit();
    }

    public void hoverSound() {
        audioSource.PlayOneShot(hoversound);
    }
    public void clickSound() {
        audioSource.PlayOneShot(clicksound);
    }


}
