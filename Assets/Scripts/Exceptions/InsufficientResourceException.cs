using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsufficientResourceException : Exception
{
    public InsufficientResourceException(string msg): base(msg) { }
}
