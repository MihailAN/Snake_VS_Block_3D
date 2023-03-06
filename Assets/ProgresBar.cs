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
    private float _finish = 1f;
    private float _finishZ;

    private void Start()
    {
        _startZ = Player.transform.position.z;
        _finishZ = Finish.position.z;
    }
    private void Update()
    {
        _mimimumReachhedZ = Mathf.Min(_mimimumReachhedZ, Player.transform.position.z);
        float t = Mathf.InverseLerp(_startZ, _finishZ + _finish, _mimimumReachhedZ);
        Slider.value = t;
    }
}
