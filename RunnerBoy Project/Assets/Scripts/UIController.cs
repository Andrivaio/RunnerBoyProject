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

    public bool isMuting;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;

    void Start(){
        audio1 = audio1.GetComponent<AudioSource>();
        audio2 = audio2.GetComponent<AudioSource>();
        audio3 = audio3.GetComponent<AudioSource>();
        audio4 = audio4.GetComponent<AudioSource>();
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
        if (isMuting == false){
            SceneManager.LoadScene("Game");
            PlayerControllerUdemy.vivo = true;
            metros = 0;
        }
        else
        SceneManager.LoadScene("GameMute");
        PlayerControllerUdemy.vivo = true;
        metros = 0;
        isMuting = true;
    }
    public void Sair() {
        Application.Quit();
    }
    public void Pause() {
        Time.timeScale = 0;
        DeslocamentoBG._offsetVelocidade = 0f;
        audio1.enabled = false;
        audio3.enabled = false;
        botaopause.SetActive(false);
        botaoresume.SetActive(true);
        pausescreen.SetActive(true);
    } 
    public void Resume() {
        Time.timeScale = 1;
        DeslocamentoBG._offsetVelocidade = 1f;
        botaopause.SetActive(true);
        botaoresume.SetActive(false);
        pausescreen.SetActive(false);
        if (isMuting == true){
            audio1.enabled = false;
            audio2.enabled = false;
            audio3.enabled = false;
            audio4.enabled = false;
        }
        else if (isMuting == false){
            audio1.enabled = true;
            audio2.enabled = true;
            audio3.enabled = true;
            audio4.enabled = true;
        }
    }
    public void Mute() {
        isMuting = true;
        audio1.enabled = false;
        audio2.enabled = false;
        audio3.enabled = false;
        audio4.enabled = false;
        botaomute.SetActive(false);
        botaosom.SetActive(true);
    } 
    public void Som() {
        isMuting = false;
        audio1.enabled = true;
        audio2.enabled = true;
        audio3.enabled = true;
        audio4.enabled = true;
        botaomute.SetActive(true);
        botaosom.SetActive(false);
    }
}
    

