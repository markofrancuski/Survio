using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI damageText;

    public void ShowText(Vector3 position, string text, Colors color = Colors.WHITE, int direction = 0)
    {
        //Position text
        transform.position = position;
        // Set Text
        damageText.SetText(text);

        // Asign Color
        Color c = Color.white;
        switch (color)
        {
            case Colors.RED:
                c = Color.red;
                break;
            case Colors.YELLOW:
                c = Color.yellow;
                break;
        }
        damageText.color = c;

        //Trigger animation
        if (direction > 0) _animator.SetTrigger("RIGHT");
        else _animator.SetTrigger("LEFT");

    }


}
