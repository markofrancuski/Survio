using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    public delegate void OnCanvasPausedEvent();
    public static OnCanvasPausedEvent CanvasPaused;
    public static OnCanvasPausedEvent CanvasUnpaused;

    public delegate void CustomFunctionDelegate();


    private void Awake()
    {
        Instance = this;
    }

    public void OnUIShow(GameObject canvasToEnable, CustomFunctionDelegate customFunc = null)
    {
        canvasToEnable.SetActive(true);
        CanvasPaused?.Invoke();
        customFunc?.Invoke();
    }

    public void OnUIHide(GameObject canvasToDisable, CustomFunctionDelegate customFunc = null )
    {
        canvasToDisable.SetActive(false);
        CanvasUnpaused?.Invoke();
        customFunc?.Invoke();
    }



}
