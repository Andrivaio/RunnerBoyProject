using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerUdemy : MonoBehaviour {
    //pulo
    public bool liberaPulo = false;
    public float forca = 7f;
    public Rigidbody2D playerRB;
    public Transform check;
    public LayerMask isGrounded;
    public float raio = 0.2f;
    //animação
    public Animator anim;
    public static bool vivo = true;
    //som
    public AudioSource hit;
    public AudioSource track;
    public AudioSource steps;
    public AudioSource jump;
    //ui
    public GameObject GameOverScreen;
    public GameObject Metros;
    //colliders
    public GameObject ColliderCorrendo;
    public GameObject ColliderPulando;

    void Start() {
        anim = GetComponent<Animator>();
        steps.Play();

    }
    void Update()
    {

        if (vivo == true)
        {
            //É CHÃO?
            liberaPulo = Physics2D.OverlapCircle(check.position, raio, isGrounded);
            //PULO PC

            if (Input.GetKeyDown(KeyCode.Space) && liberaPulo == true)
            {
                playerRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                anim.SetBool("Run", false);
                anim.SetBool("Jump", true);
                steps.Pause();
                jump.Play();
            }
            //PULO TOUCH
            else if (Input.GetMouseButtonDown(0) && liberaPulo == true)
            {
                if (!EventSystem.current.IsPointerOverGameObject()) { 
                playerRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                anim.SetBool("Run", false);
                anim.SetBool("Jump", true);
                steps.Pause();
                jump.Play();

            }
            }
        }
        else steps.Stop();
        //COLLIDERS
        if (liberaPulo == true){
            ColliderCorrendo.SetActive(true);
            ColliderPulando.SetActive(false);
        }
        if (liberaPulo == false){
            ColliderCorrendo.SetActive(false);
            ColliderPulando.SetActive(true);
        }
    } 
    //PULO
    private void OnCollisionEnter2D(Collision2D outro) {
        if (outro.gameObject.CompareTag("Ground")) {
            anim.SetBool("Jump", false);
            anim.SetBool("Run", true);
            steps.Play();
        }
    }
    //MORTE
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("ObsCima"))
        {
            vivo = false;
            anim.SetBool("Jump", false);
            anim.SetBool("HeadHit", true);
            hit.Play();
            track.Stop();
            steps.Stop();
            StartCoroutine("GameOver");
            Metros.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("ObstaculoBaixo"))
        {
            vivo = false;
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", true);
            hit.Play();
            track.Stop();
            steps.Stop();
            StartCoroutine("GameOver");
            Metros.SetActive(false);
        }
        else collision.gameObject.CompareTag("ObstaculoBaixo"); {
            vivo = false;
            anim.SetBool("Run", false);
            anim.SetBool("Fall", true);
            hit.Play();
            track.Stop();
            steps.Stop();
            StartCoroutine("GameOver");
            Metros.SetActive(false);
        }
    }
    IEnumerator GameOver() {
        yield return new WaitForSeconds(1f);
        GameOverScreen.SetActive(true);
        StopCoroutine("GameOver");
    }
}

