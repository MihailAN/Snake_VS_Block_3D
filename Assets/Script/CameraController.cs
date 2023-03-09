using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform Target;
    private float _distance;
    private void Start()
    {
        Vector3 transformPosition = transform.position;
        _distance = transformPosition.z;
    }
    private void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.z = Target.position.z+_distance;
        transform.position = transformPosition;
    }
}
