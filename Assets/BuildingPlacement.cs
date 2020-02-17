using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{

    [SerializeField] private Sprite _sprite;

    private bool _lClick;
    private bool _rClick;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _lClick = Input.GetMouseButtonUp(0);
        _rClick = Input.GetMouseButtonUp(1);

        if (_lClick ^ _rClick)
        {
            //Left click Place building
            if(_lClick)
            {
                //Place building
                BuildingManager.Instance.OnBuildingPlaced();
            }

            //Right click cancel placement
            if (_rClick)
            {
                //Cancel building
                BuildingManager.Instance.OnBuildingPlacementCancel();
            }
        }
    }



}
