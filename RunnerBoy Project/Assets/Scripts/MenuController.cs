using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    private Rigidbody2D ObstaculoRB;
    private GameController _GameController;
    public float velocidade;

    void Start()
    {
        ObstaculoRB = GetComponent<Rigidbody2D>();
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
    }
    void FixedUpdate()
    {
        MoveObjeto();
    }
    void MoveObjeto()
    {
        transform.Translate(Vector2.left * velocidade * Time.smoothDeltaTime, 0);
    }
}
