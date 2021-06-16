using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Propriedade do Chão
    [Header("Configuração do Chão")]
    public float        _ChaoDestruido;
    public float        _ChaoTamanho;
    public float        _ChaoVelocidade;
    public GameObject   _ChaoPrefab;

    // Propriedade do Obstáculo
    [Header("Configuração do Cone")]
    public float        _ConeTempo;
    public float        _ConeVelocidade;
    public GameObject   _ConePrefab;

    // Propriedade do Obstáculo
    [Header("Configuração da Placa Verde")]
    public float _PlacaVerdeTempo;
    public float _PlacaVerdeVelocidade;
    public GameObject _PlacaVerdePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstaculo");
    }

    // Update is called once per frame
    void Update()
    {
        //PARA TUDO
        if (PlayerControllerUdemy.vivo == false)
        {
             _ChaoVelocidade = 0;
             _ConeVelocidade = 0;
             _PlacaVerdeVelocidade = 0;

            StopCoroutine("SpawnObstaculo");
        }

        //AUMENTO DE DIFICULDADE
        if (UIController.metros == 10)
        {
            _ConeVelocidade = _ConeVelocidade * 2;
            _PlacaVerdeVelocidade = _PlacaVerdeVelocidade * 2;
        }
    }

    IEnumerator SpawnObstaculo()
    {
        //yield return new WaitForSeconds(_ObstaculoTempo);
        //GameObject ObjetoPregos = Instantiate(_ObstaculoPrefab);
        yield return new WaitForSeconds(_ConeTempo);
        GameObject ObjetoCone = Instantiate(_ConePrefab);

        yield return new WaitForSeconds(_PlacaVerdeTempo);
        GameObject ObjetoPlacaVerde = Instantiate(_PlacaVerdePrefab);

        StartCoroutine("SpawnObstaculo");

    }
}
