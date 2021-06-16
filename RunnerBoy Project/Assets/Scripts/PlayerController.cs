using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 0f;
    public bool isGrounded = true;

    private Animator anim;
    private Rigidbody2D rigi;

    public LayerMask layerGround;
    public Transform checkGround;
    public string isGroundBool = "eChao";



    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        MovimentaPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MovimentaPlayer()
    {
        transform.Translate(new Vector3(speed,0,0));
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));

        if (Physics2D.OverlapCircle(checkGround.transform.position, 2.0f, layerGround))
        {
            anim.SetBool(isGroundBool,true);
            isGrounded = true;
        }

        else
        {
            anim.SetBool(isGroundBool, false);
            isGrounded = false;
        }
    }
}
