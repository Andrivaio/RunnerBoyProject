using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUdemy : MonoBehaviour
{
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

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (vivo == true)
        {
            //É CHÃO?

            liberaPulo = Physics2D.OverlapCircle(check.position, raio, isGrounded);

            //PULO
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                anim.SetBool("Run", false);
                anim.SetBool("Jump", true);
            }
        }
    }

    //PULO
    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Run", true);
        }
    }

    //MORTE
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObsCima"))
        {
            vivo = false;
            anim.SetBool("Jump", false);
            anim.SetBool("HeadHit", true);
        }
        else if (collision.gameObject.CompareTag("ObstaculoBaixo"))
        {
            vivo = false;
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", true);

        }

        else collision.gameObject.CompareTag("ObstaculoBaixo");
        {
            vivo = false;
            anim.SetBool("Run", false);
            anim.SetBool("Fall", true);
        }
    }
    
}

