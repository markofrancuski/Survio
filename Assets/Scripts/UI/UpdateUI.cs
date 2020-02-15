using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class UpdateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ResourceType _type;

    private void OnEnable()
    {
        InventoryManager.ResourceChanged += Update_UI;
    }

    private void OnDisable()
    {
        InventoryManager.ResourceChanged -= Update_UI;
    }

    private void Update_UI(ResourceType type, float val)
    {
        if(_type == type) _text.SetText(val.ToString("F2"));
    }

}
