using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text textmetros;
    public Text textkilometros;
    public static float metros;
    public float kilometros;
    public int limitemetros;
    public GameObject km;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textmetros.text = metros.ToString("0");
        textkilometros.text = kilometros.ToString("0");
        metros += Time.deltaTime * 2f;

        if (metros >= limitemetros)
        {
            kilometros = kilometros + 1f;
            metros = 0;

            km.GetComponent<Text>().enabled = true;
        }

        /*if (PlayerControllerUdemy.vivo == false)
        {
            Time.timeScale = 0;
        }*/
    }
}
