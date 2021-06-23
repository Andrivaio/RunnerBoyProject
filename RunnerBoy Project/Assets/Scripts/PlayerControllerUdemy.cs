using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject GameOverScreen;
    public GameObject Metros;

    void Start() {
        anim = GetComponent<Animator>();
        steps.Play();
    }
    void Update() {
        if (vivo == true) {
            //É CHÃO?
            liberaPulo = Physics2D.OverlapCircle(check.position, raio, isGrounded);

            //PULO
            if (Input.GetKeyDown(KeyCode.Space) && liberaPulo == true) {
                playerRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                anim.SetBool("Run", false);
                anim.SetBool("Jump", true);
                steps.Pause();
                jump.Play();
            }
        }
        else steps.Stop();
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
            GameOverScreen.SetActive(true);
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
            GameOverScreen.SetActive(true);
            Metros.SetActive(false);
        }
        else collision.gameObject.CompareTag("ObstaculoBaixo"); {
            vivo = false;
            anim.SetBool("Run", false);
            anim.SetBool("Fall", true);
            hit.Play();
            track.Stop();
            steps.Stop();
            GameOverScreen.SetActive(true);
            Metros.SetActive(false);
        }
    }
}

