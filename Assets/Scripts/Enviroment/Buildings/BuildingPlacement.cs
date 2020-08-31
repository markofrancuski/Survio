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

    [SerializeField] private Vector3 gridSize;

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

            if(Input.GetKeyUp(KeyCode.R))
            {
                transform.Rotate(new Vector3(0, 0, 90f));
            }

            //Get Current Position of the mouse and round position.
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
            currentPos.x = Mathf.Round(currentPos.x / gridSize.x );
            currentPos.y = Mathf.Round(currentPos.y / gridSize.y) ;
            currentPos.z = 0;

            //Apply 'snaped' position to this game object
            transform.position = currentPos;

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
                    catch (SkillNotUnlockedException e) { Debug.Log(e.Message); }
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
        BuildingPlacementChecker.OnValidPlace += TintGreen;
        BuildingPlacementChecker.OnInvalidPlace += TintRed;

    }

    private void OnDisable()
    {
        BuildingManager.BuildingClicked -= BuildingSelected;
        BuildingManager.BuildingPlacementCancel -= BuildingDeselected;
        BuildingPlacementChecker.OnValidPlace -= TintGreen;
        BuildingPlacementChecker.OnInvalidPlace -= TintRed;
    }


    private void BuildingSelected()
    {       
        _sprite.sprite = BuildingManager.Instance.selectedBuilding.bIcon;
        TintGreen();
        //CheckForInput = true;
        //Wait for 0.1s because it executes update in same frame, and places building
        //which we don't want to have when we click on button to select building.
        Invoke("WaitForInput", .1f);
    }
    private void WaitForInput() => CheckForInput = true;

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
