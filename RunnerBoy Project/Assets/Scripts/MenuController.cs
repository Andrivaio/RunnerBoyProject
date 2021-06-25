using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuController : MonoBehaviour
{
    public GameObject logo;
    public GameObject blackscreen;
    public AudioSource trackPlay;
    public GameObject botaoStart;
    public GameObject botaoTutorial;
    public GameObject botaoCreditos;
    public GameObject botaoSair;
    public GameObject telaLoading;
    //creditos
    public GameObject telaCreditos;
    public GameObject botaoVoltar;
    //tutorial
    public GameObject telaTutorial;
    void Start(){
        StartCoroutine("Intro");
        StartCoroutine("EndIntro");
        StartCoroutine("HideLogo");
    }
    void Update(){
    
    }
    public void PlayAgain(){
        SceneManager.LoadScene("Game");
        PlayerControllerUdemy.vivo = true;
        telaLoading.SetActive(true);
    }
    public void Tutorial()
    {
        //botões
        botaoStart.SetActive(false);
        botaoTutorial.SetActive(false);
        botaoCreditos.SetActive(false);
        botaoSair.SetActive(false);
        botaoVoltar.SetActive(true);
        //telas
        telaTutorial.SetActive(true);
        telaCreditos.SetActive(false);
    }
    public void Credito(){
        //botões
        botaoStart.SetActive(false);
        botaoTutorial.SetActive(false);
        botaoCreditos.SetActive(false);
        botaoSair.SetActive(false);
        botaoVoltar.SetActive(true);
        //telas
        telaTutorial.SetActive(false);
        telaCreditos.SetActive(true);
    }
    public void Sair(){
        Application.Quit();
    }
    public void Voltar(){
        //botões
        botaoStart.SetActive(true);
        botaoTutorial.SetActive(true);
        botaoCreditos.SetActive(true);
        botaoSair.SetActive(true);
        botaoVoltar.SetActive(false);
        //telas
        telaTutorial.SetActive(false);
        telaCreditos.SetActive(false);
    }
    IEnumerator Intro() {
        yield return new WaitForSeconds(2f);
        logo.SetActive(true);
        StopCoroutine("Intro");
    }
    IEnumerator EndIntro(){
        yield return new WaitForSeconds(7f);
        blackscreen.SetActive(false);
        trackPlay.Play();
        //botões
        botaoStart.SetActive(true);
        botaoTutorial.SetActive(true);
        botaoCreditos.SetActive(true);
        botaoSair.SetActive(true);
        botaoVoltar.SetActive(false);
        //telas
        telaTutorial.SetActive(false);
        telaCreditos.SetActive(false);
        StopCoroutine("EndIntro");
    }
    IEnumerator HideLogo(){
        yield return new WaitForSeconds(6f);
        logo.SetActive(false);
        StopCoroutine("HideLogo");
    }
}
