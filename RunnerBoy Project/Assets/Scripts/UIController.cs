using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    
    public Text textmetros;
    public float metros;
    public bool start;
  
    void Start() {
       
    }
    void Update() {
        start = true;

        if (PlayerControllerUdemy.vivo == true && start == true) {
            textmetros.text = metros.ToString("0");
            metros += Time.deltaTime * 5f;
        }

        if (PlayerControllerUdemy.vivo == false && start == false)
        {
            metros = Time.deltaTime;
        }
    }
}
