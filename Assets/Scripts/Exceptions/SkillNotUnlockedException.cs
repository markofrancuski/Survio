using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNotUnlockedException : Exception
{
    public SkillNotUnlockedException(string msg) : base(msg) { }
}
