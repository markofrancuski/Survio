using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private GameObject parent;

    public void ShowText(Vector3 position, string text, Colors color = Colors.WHITE)
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

        parent.SetActive(true);

        //Trigger animation
        int direction = Random.Range(0, 2);
        if (direction > 0) _animator.SetTrigger("RIGHT");
        else _animator.SetTrigger("LEFT");
    }

    public void Disable()
    {
        parent.SetActive(false);
    }

}
