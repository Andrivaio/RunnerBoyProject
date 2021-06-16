using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{

    private Rigidbody2D ObstaculoRB;
    private GameController _GameController;
    


    // Start is called before the first frame update
    void Start()
    {
        ObstaculoRB = GetComponent<Rigidbody2D>();
        //ObstaculoRB.velocity = new Vector2(-5f, 0);

        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveObjeto();
    }

    void MoveObjeto()
    {
        transform.Translate(Vector2.left * _GameController._ConeVelocidade * Time.smoothDeltaTime, 0);

        transform.Translate(Vector2.left * _GameController._PlacaVerdeVelocidade * Time.smoothDeltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log ("Tocou no Obstáculo");
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        Debug.Log("O Obstáculo foi Destuído");
    }
}
