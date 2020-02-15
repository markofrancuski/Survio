using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraKick : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    [SerializeField] private string _triggerName;

    public void Effect() { _animator.SetTrigger(_triggerName);  }

    private void OnEnable()
    {
        PlayerInput.OnFire += Effect;
    }

    private void OnDisable()
    {
        PlayerInput.OnFire -= Effect;
    }
}
