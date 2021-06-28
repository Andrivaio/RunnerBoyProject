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
}
    

