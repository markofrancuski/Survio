using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidPlacementException : Exception
{
    public InvalidPlacementException(string msg) : base(msg) { }
}
