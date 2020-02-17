using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{

    private Vector3 mousePos;

    [SerializeField] private SpriteRenderer _sprite;

    public bool CheckForInput;
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
        if (!CheckForInput) return;

        if(BuildingManager.Instance.selectedBuilding != null)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                BuildingManager.Instance.OnBuildingPlacementCancel();
                return;
            }

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            if (transform.position != mousePos)
            {
                transform.position = Vector3.Lerp(transform.position, mousePos, 0.1f);
            }

            _lClick = Input.GetMouseButtonUp(0);
            _rClick = Input.GetMouseButtonUp(1);

            if (_lClick ^ _rClick)
            {
                //Left click Place building
                if (_lClick)
                {
                    Debug.Log("Left click");
                    //Try Place building
                    try
                    {
                        BuildingManager.Instance.OnTryBuildingPlace(transform);
                    }
                    catch (InvalidPlacementException e) { Debug.Log(e.Message); }
                    catch (InsufficientResourceException e) { Debug.Log(e.Message); }
                    catch (Exception e) { Debug.Log(e.Message); }

                }

                //Right click cancel placement
                if (_rClick)
                {
                    Debug.Log("Right click");
                    //Cancel building
                    BuildingManager.Instance.OnBuildingPlacementCancel();
                }
            }

           
        }
    }

    private void OnEnable()
    {
        BuildingManager.BuildingClicked += BuildingSelected;
        BuildingManager.BuildingPlacementCancel += BuildingDeselected;

    }

    private void OnDisable()
    {
        BuildingManager.BuildingClicked -= BuildingSelected;
        BuildingManager.BuildingPlacementCancel -= BuildingDeselected;
    }


    private void BuildingSelected()
    {       
        _sprite.sprite = BuildingManager.Instance.selectedBuilding.bIcon;
        TintGreen();
        CheckForInput = true;
    }
    private void BuildingDeselected()
    {
        CheckForInput = false;
        _sprite.sprite = null;
        transform.position = Vector3.zero;
    }

    public void TintRed()
    {
        _sprite.color = Color.red;
    }

    public void TintGreen()
    {
        _sprite.color = Color.green;
    }

    public void TintNormal()
    {
        _sprite.color = Color.white;
    }
}
