using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Propriedade do Chão
    [Header("Configuração do Chão")]
    public float _ChaoDestruido;
    public float _ChaoTamanho;
    public float _ChaoVelocidade;
    public GameObject _ChaoPrefab;
    // Propriedade dos Obstáculos
    [Header("Configuração do Bloco de Obstáculos")]
    public GameObject[] _BlocoObstaculos;
    public int _BlocoNumero;
    public float _BlocoTempo;
    public float _BlocoVelocidade;
    // Propriedade do Timer
    [Header("Timer")]
    public float timer;

    void Start(){
        StartCoroutine("SpawnBloco");
    }
    void Update(){
        timer += Time.deltaTime;
        _BlocoNumero = Random.Range(0, 8);
        //PARA TUDO
        if (PlayerControllerUdemy.vivo == false){
            _ChaoVelocidade = 0;
            _BlocoVelocidade = 0;
            StopCoroutine("SpawnBloco");
        }
        //AUMENTO DE DIFICULDADE
        if (timer >= 60){
            _ChaoVelocidade = _ChaoVelocidade * 1.1f;
            _BlocoVelocidade = _BlocoVelocidade * 1.1f;
            _BlocoTempo = _BlocoTempo * 0.9f; 
            timer = 0;
        }
    }
    IEnumerator SpawnBloco(){
        yield return new WaitForSeconds(_BlocoTempo);
        GameObject Bloco = Instantiate(_BlocoObstaculos[_BlocoNumero]);
        StartCoroutine("SpawnBloco");
    }
}
