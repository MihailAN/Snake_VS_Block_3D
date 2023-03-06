using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private Game haed;
    [SerializeField]
    private TextMeshPro textFood;

    private int _randomFood;

    private void Start()
    {        
        _randomFood = Random.Range(1, 5);
        textFood.text = _randomFood.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _randomFood; i++)
        {
            haed.AddTail();
        }
        Destroy(gameObject);
    }
}
