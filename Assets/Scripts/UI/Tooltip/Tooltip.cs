using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public int Index;

    [SerializeField] protected Vector3 _initialPos;

    [SerializeField] protected TextMeshProUGUI[] _textComponents;
    [SerializeField] protected string[] _contexts;

    public virtual void Show(Vector3 position, string[] strings)
    {

    }

    public virtual void Hide()
    {

    }
}
