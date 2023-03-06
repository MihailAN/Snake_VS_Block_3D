using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Block : MonoBehaviour
{
    [SerializeField]
    private Game haed;
    [SerializeField]
    private Color colorMin;
    [SerializeField]
    private Color colorMax;
    [SerializeField]
    private TextMeshPro textFood;
    
    public int MinBlock;
    public int MaxBlock;

    private int _randomDameg;
    private float _smoothness = 0;

    void Start()
    {
        _randomDameg = UnityEngine.Random.Range(MinBlock, MaxBlock);
        textFood.text = _randomDameg.ToString();
        GradientColer();
    }

    private void GradientColer()
    {
        Color[] gColor = new Color[MaxBlock];
        for (int i = 0; i < MaxBlock; i++)
        {
            _smoothness += 1f / MaxBlock;

            gColor[i] = (Color.Lerp(colorMin, colorMax, _smoothness));
        }
        GetComponent<Renderer>().material.color = gColor[_randomDameg];
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
            haed.RemoveTail();
            if (_randomDameg == 0)
            {
                Destroy(gameObject);
            }
        }
    } 
    
}
