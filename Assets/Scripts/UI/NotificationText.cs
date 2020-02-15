using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationText : MonoBehaviour
{

    public TextMeshProUGUI text;

    public void Setup(string str)
    {
        text.SetText(str);
        Destroy(gameObject, 3f);
    }

}
