using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    public Tooltip[] tooltips;

    private void Awake()
    {
        Instance = this;    
    }

    public void Show(Vector3 pos, int index, string[] strings)
    {
        tooltips[index].Show(pos, strings);
    }

    public void Hide(int index)
    {
        tooltips[index].Hide();
    }

}
