using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text textmetros;
    public float metros;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textmetros.text = metros.ToString("0");
        metros += Time.deltaTime * 5f;

       /* if (PlayerControllerUdemy.vivo == false)
        {
            
        } */
    }
}
