using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasInputManager : MonoBehaviour
{
    public static CanvasInputManager Instance;

    /// <summary>
    /// Logic Value for Checking Input
    /// </summary>
    public bool CheckForInput;

    /// <summary>
    /// List of all canvases that are available for player to open/close.
    /// </summary>
    [Space]
    public CanvasInfo[] AvailableCanvases;

    public List<CanvasInfo> ActiveCanvases;

    [SerializeField] private bool _isCanvasInteractable;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckForInput) return;

        for (int i = 0; i < AvailableCanvases.Length; i++)
        {
            if (Input.GetKeyUp(AvailableCanvases[i].UIKeyCode))
            {
                if (AvailableCanvases[i].IsOpen)
                {
                    AvailableCanvases[i].Close();
                }
                else
                {
                    AvailableCanvases[i].Open();
                    //LastOpened = AvailableCanvases[i];
                }

            }
        }
        if (_isCanvasInteractable) return;
        if (ActiveCanvases.Count > 0 && Input.GetKeyUp(KeyCode.Escape) ) RemoveLast();
    }

    private void OnEnable()
    {
        //When game starts check for input
        /*SubscribeToInput;
        UnsubscribeToInput;*/
    }
    private void OnDisable()
    {


    }

    /// <summary>
    /// Subscribes the method to the event and starts checking for input. Invokes at the start game.
    /// </summary>
    private void SubscribeToInput() => CheckForInput = true;
    /// <summary>
    /// Unsubscribes the method to the event and stops checking for input. Invokes when player dies or when game is not started yet.
    /// </summary>
    private void UnsubscribeToInput() => CheckForInput = false;
    /// <summary>
    /// Loops thru all canvases and deactivates them.
    /// </summary>
    public void CloseAll() { for (int i = 0; i < AvailableCanvases.Length; i++) AvailableCanvases[i].Close(); }
    /// <summary>
    /// Closes Canvas.
    /// Assigned In Inspector for OnButtonClickEvent.
    /// </summary>
    /// <param name="index">Index of a canvas we want to close. </param>
    public void CloseOne(int index) => AvailableCanvases[index].Close(); 
    /// <summary>
    /// Closing and removing last active Canvas.
    /// </summary>
    private void RemoveLast()
    {
        ActiveCanvases[ActiveCanvases.Count - 1].Close();
    }

    public void EnableSpecialCanvas() => _isCanvasInteractable = true;
    public void DisableSpecialCanvas() => _isCanvasInteractable = false;

}

[Serializable]
public class CanvasInfo
{
    /// <summary>
    /// Name of Canvas used only in inspector to name this object(Canvas).
    /// </summary>
    [Header("Debug")]
    public string CanvasName;
    /// <summary>
    /// Keycode on which you want to enable/disable this object(Canvas)
    /// </summary>
    [Space]
    public KeyCode UIKeyCode;
    /// <summary>
    /// GameObject(Canvas) we are going to enable/disable.
    /// </summary>
    public GameObject CanvasObject;
    /// <summary>
    /// Logic value used for checking state of Canvas and interacts according to the value.
    /// </summary>
    public bool IsOpen;
    /// <summary>
    /// Event That is being used to Call additional functionaly to executed wehn this Canvas is opened.
    /// </summary>
    public UnityEvent OpenEvent;
    /// <summary>
    /// Event That is being used to Call additional functionaly to executed wehn this Canvas is closed.
    /// </summary>
    public UnityEvent CloseEvent;

    /// <summary>
    /// Opens canvas and sets boolean value to true
    /// </summary>
    public void Open()
    {
        Debug.Log($"Opening Canvas with name: {CanvasName}");
        CanvasManager.Instance.OnUIShow(CanvasObject);
        CanvasInputManager.Instance.ActiveCanvases.Add(this);
        //CanvasObject.SetActive(true);
        IsOpen = true;
        OpenEvent?.Invoke();
    }

    /// <summary>
    /// Closes canvas and sets boolean value to false.
    /// </summary>
    public void Close()
    {
        Debug.Log($"Closing Canvas with name: {CanvasName}");
        CanvasManager.Instance.OnUIHide(CanvasObject);
        CanvasInputManager.Instance.ActiveCanvases.Remove(this);
        //CanvasObject.SetActive(false);
        IsOpen = false;
        CloseEvent?.Invoke();
    }

}