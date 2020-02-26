using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    public virtual void OnButtonClick()
    {
        Debug.Log($"Button {gameObject.name} is Clicked");
    }
}
