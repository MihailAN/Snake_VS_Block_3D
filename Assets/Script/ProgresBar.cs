using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresBar : MonoBehaviour
{
    public Transform Player;
    public Transform Finish;
    public Slider Slider;

    private float _startZ;
    private float _mimimumReachhedZ;    
    private float _finishZ;

    private void Start()
    {
        _startZ = Player.transform.position.z;
        _finishZ = Finish.position.z;
        _mimimumReachhedZ = Player.transform.position.z;
    }
    private void Update()
    {
        float currentY = Player.transform.position.z;
        float t = Mathf.InverseLerp(_startZ, _finishZ , currentY);
        if (_mimimumReachhedZ<currentY)
        {
             Slider.value = t;
            _mimimumReachhedZ = currentY;
        }
    }
}
