using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    public BigDouble prestige;
    public BigDouble volunteer;
    public BigDouble volunteerUpgradeLevel;
    public BigDouble tree;
    public BigDouble treeUpgradeLevel;

    public Data()
    {
        prestige = 0;
        volunteer = 0;
        volunteerUpgradeLevel = 0;
        tree = 0;
        treeUpgradeLevel = 0;
    }
}
