using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandClaimer : BaseBuilding
{
    [SerializeField] private int _buildRange;
    public int BuildRange
    {
        get { return _buildRange; }
        private set { _buildRange = value; }
    }

}
