using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {
    
    public TMP_Text textmetros;
    public TMP_Text textpontos;
    public static float metros;
    public bool start;

    public GameObject botaopause;
    public GameObject botaoresume;
    public GameObject botaomute;
    public GameObject botaosom;
    public GameObject pausescreen;

    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;

    void Start() {
        
    }
    void Update() {
        start = true;

        if (PlayerControllerUdemy.vivo == true && start == true) {
            textmetros.text = metros.ToString("0") + "M";
            textpontos.text = metros.ToString("0") + " METROS";
            metros += Time.deltaTime * 6f;
        }
        if (PlayerControllerUdemy.vivo == false && start == false) {
            metros = Time.deltaTime;
        }
    }
    public void PlayAgain() {
        SceneManager.LoadScene("Game");
        PlayerControllerUdemy.vivo = true;
        metros = 0;
    }
    public void Sair() {
        Application.Quit();
    }
    public void Pause() {
        Time.timeScale = 0;
        botaopause.SetActive(false);
        botaoresume.SetActive(true);
        pausescreen.SetActive(true);
        Debug.Log("Pause");
    } 
    public void Resume() {
        Time.timeScale = 1;
        botaopause.SetActive(true);
        botaoresume.SetActive(false);
        pausescreen.SetActive(false);
    }
    public void Mute() {
        audio1.Stop();
        audio2.Stop();
        audio3.Stop();
        audio4.Stop();
        botaomute.SetActive(false);
        botaosom.SetActive(true);
    } 
    public void Som() {
        audio1.Play();
        audio2.Play();
        audio3.Play();
        audio4.Play();
        botaomute.SetActive(true);
        botaosom.SetActive(false);
    }
}
    

