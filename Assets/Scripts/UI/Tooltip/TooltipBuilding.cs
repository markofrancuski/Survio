using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipBuilding : Tooltip
{

    /// <summary>
    /// Binds all the string to corresponding textcomponent
    /// </summary>
    /// <param name="position">Position where to position tooltip.</param>
    /// <param name="strings">Array of strings to be bind and displayed.</param>
    public override void Show(Vector3 position, string[] strings)
    {
        _contexts = strings;
        int numberOfTexts = _contexts.Length;

        for (int i = 0; i < _textComponents.Length; i++)
        {
            if (i < numberOfTexts)
            {
                //Activate component
                _textComponents[i].SetText(_contexts[i]);
            }
            else
            {
                //Deactivate them
                _textComponents[i].SetText(string.Empty);
            }
        }

        transform.position = position;
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        transform.position = _initialPos;
        gameObject.SetActive(false);
    }
}
