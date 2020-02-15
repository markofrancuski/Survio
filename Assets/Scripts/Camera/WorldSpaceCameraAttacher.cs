using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceCameraAttacher : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    
    private void Awake()
    {
       canvas.worldCamera = Camera.main;
    }

}
