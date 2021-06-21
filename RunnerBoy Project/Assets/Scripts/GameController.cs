using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // Propriedade do Chão
    [Header("Configuração do Chão")]
    public float _ChaoDestruido;
    public float _ChaoTamanho;
    public float _ChaoVelocidade;
    public GameObject _ChaoPrefab;

    // Propriedade do Obstáculo
    [Header("Configuração do Cone")]
    public float _ConeTempo;
    public float _ConeVelocidade;
    public GameObject _ConePrefab;

    // Propriedade do Obstáculo
    [Header("Configuração da Placa Verde")]
    public float _PlacaVerdeTempo;
    public float _PlacaVerdeVelocidade;
    public GameObject _PlacaVerdePrefab;

    // Propriedade do Obstáculo
    [Header("Configuração do Prego")]
    public float _PregoTempo;
    public float _PregoVelocidade;
    public GameObject _PregoPrefab;

    [Header("Timer")]
    public float timer;

    void Start() {
        StartCoroutine("SpawnCone");
        StartCoroutine("SpawnPlacaVerde");
        StartCoroutine("SpawnPrego");
    }
    void Update() {
        timer += Time.deltaTime;
       
        //PARA TUDO
        if (PlayerControllerUdemy.vivo == false) {
            _ChaoVelocidade = 0;
            _ConeVelocidade = 0;
            _PlacaVerdeVelocidade = 0;
            _PregoVelocidade = 0;

            StopCoroutine("SpawnCone");
            StopCoroutine("SpawnPlacaVerde");
            StopCoroutine("SpawnPrego");
        }
        //AUMENTO DE DIFICULDADE
        if (timer >= 30) {
            _ChaoVelocidade = _ChaoVelocidade * 1.2f;
            _ConeVelocidade = _ConeVelocidade * 1.2f;
            _PlacaVerdeVelocidade = _PlacaVerdeVelocidade * 1.2f;
            _PregoVelocidade = _PregoVelocidade * 1.2f;

            _ConeTempo = _ConeTempo * 0.8f;
            _PlacaVerdeTempo = _PlacaVerdeTempo * 0.8f;
            _PregoTempo = _PregoTempo * 0.8f;

            timer = 0;
        }    
    }
    IEnumerator SpawnCone() {
        yield return new WaitForSeconds(_ConeTempo);
        GameObject ObjetoCone = Instantiate(_ConePrefab);
        StartCoroutine("SpawnCone");
    }
    IEnumerator SpawnPlacaVerde() {
        yield return new WaitForSeconds(_PlacaVerdeTempo);
        GameObject ObjetoCone = Instantiate(_PlacaVerdePrefab);
        StartCoroutine("SpawnPlacaVerde");
    }
    IEnumerator SpawnPrego() {
        yield return new WaitForSeconds(_PregoTempo);
        GameObject ObjetoCone = Instantiate(_PregoPrefab);
        StartCoroutine("SpawnPrego");
    }
}
