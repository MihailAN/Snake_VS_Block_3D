using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{   
    [SerializeField]
    private AnimatorControl AnimatorControl;
    [SerializeField]
    private float Speed=0.1f;
    [SerializeField]
    private float Sensitivity;
    [SerializeField]
    private float BounceSpeed;
    [SerializeField]
    private Transform Finesh;

    private AudioSource _audio;
    private Vector3 _previousMousePisition;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        AnimatorControl.StartMoving();
    }
    private void Update()
    {
        transform.position += Vector3.forward*Speed*Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePisition;
            Vector3 transformPosition = transform.position;
            transformPosition.x += delta.x* Sensitivity;

            if (transformPosition.x > 2.2f)
            {
                transformPosition.x = 2.2f;
            }
            if (transformPosition.x < -2.2f)
            {
                transformPosition.x = -2.2f;
            }            
            transform.position = transformPosition;            
        }
        _previousMousePisition = Input.mousePosition;
    }
    public void Bounce()
    {
        _audio.Play();
        GetComponent<ParticleSystem>().Play();
        transform.position += new Vector3(0,0 ,-BounceSpeed ); 
    }
}
