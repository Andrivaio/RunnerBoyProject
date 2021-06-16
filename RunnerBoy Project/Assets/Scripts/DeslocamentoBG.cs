using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeslocamentoBG : MonoBehaviour
{

    private Renderer    _objetoRender;
    private Material    _objetoMaterial;
    public float        _offset; //deslocamento
    public float        _offsetIncremento;
    public float        _offsetVelocidade;

    public string       _sortingLayer;
    public int          _orderinLayer;



    // Start is called before the first frame update
    void Start()
    {
        _objetoRender = GetComponent<MeshRenderer>();

        _objetoRender.sortingLayerName = _sortingLayer;
        _objetoRender.sortingOrder = _orderinLayer;

        _objetoMaterial = _objetoRender.material;

    }

    // Update is called once per frame
    void Update()
    {
        _offset += _offsetIncremento; //offset = offset + incremento (+2, +3, +4)
        _objetoMaterial.SetTextureOffset("_MainTex", new Vector2(_offset * _offsetVelocidade, 0));

        //STOP BG
        if (PlayerControllerUdemy.vivo == false)
        {
            _offsetVelocidade = 0;
          
        }
    }
}
