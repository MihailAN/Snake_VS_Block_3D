using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{   
    public float Speed=0.1f;
    public float Sensitivity;    
    public float BounceSpeed;
    public Transform Finesh;

    private Vector3 _previousMousePisition;

    
    private void Update()
    {        
        transform.position += Vector3.forward*Speed;
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
        GetComponent<ParticleSystem>().Play();
        transform.position += new Vector3(0,0 ,-BounceSpeed ); 
    }
}
