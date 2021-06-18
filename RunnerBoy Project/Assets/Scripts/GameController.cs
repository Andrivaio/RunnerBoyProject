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

    [Header("Timer")]
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstaculo");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //PARA TUDO
        if (PlayerControllerUdemy.vivo == false)
        {
            _ChaoVelocidade = 0;
            _ConeVelocidade = 0;
            _PlacaVerdeVelocidade = 0;

            StopCoroutine("SpawnObstaculo");
        }
        //AUMENTO DE VELOCIDADE
        if (timer >= 10)
        {
            _ChaoVelocidade = _ChaoVelocidade * 1.2f;
            _ConeVelocidade = _ConeVelocidade * 1.2f;
            _PlacaVerdeVelocidade = _PlacaVerdeVelocidade * 1.2f;

            timer = 0;
        } 
    }
    IEnumerator SpawnObstaculo()
    {

        yield return new WaitForSeconds(_ConeTempo);
        GameObject ObjetoCone = Instantiate(_ConePrefab);

        yield return new WaitForSeconds(_PlacaVerdeTempo);
        GameObject ObjetoPlacaVerde = Instantiate(_PlacaVerdePrefab);

        StartCoroutine("SpawnObstaculo");
    }
}
