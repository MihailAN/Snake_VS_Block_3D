using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private CameraController cameraController;    
    [SerializeField]
    private GameObject PanelWin;

    private void OnTriggerEnter(Collider other)
    {
        cameraController.enabled = false;
        PanelWin.SetActive(true);
    }
}
