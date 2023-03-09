using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Block : MonoBehaviour
{
    [SerializeField]
    private Game game;
    [SerializeField]
    private Color colorMin;
    [SerializeField]
    private Color colorMax;
    [SerializeField]
    private TextMeshPro textFood;   
    [SerializeField]
    private Renderer rendererBloc;
    [SerializeField]
    private int minBlock;
    [SerializeField]
    private int maxBlock;

    private int _randomDameg;
    private float _smoothness = 0;

    void Start()
    {
        _randomDameg = UnityEngine.Random.Range(minBlock, maxBlock);
        textFood.text = _randomDameg.ToString();
        GradientColer();
    }
        private void GradientColer()
    {
        Color[] gColor = new Color[maxBlock];
        for (int i = 0; i < maxBlock; i++)
        {
            _smoothness += 1f / maxBlock;
            gColor[i] = (Color.Lerp(colorMin, colorMax, _smoothness));
        }
        rendererBloc.GetComponent<Renderer>().material.color = gColor[_randomDameg];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player plaear))
        {
            Vector3 normalV = -collision.contacts[0].normal;
            float dot = Vector3.Dot(normalV, Vector3.forward);
            if (dot < 0.5) 
            plaear.Bounce();

            _randomDameg -= 1;
            textFood.text = _randomDameg.ToString();
            game.RemoveTail();
            if (_randomDameg == 0)
            {
                Destroy(gameObject);
            }
        }
    } 
    
}
