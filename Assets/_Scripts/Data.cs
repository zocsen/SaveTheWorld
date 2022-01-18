using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    // Player Data
    public BigDouble gems;
    public BigDouble prestige;
    public BigDouble volunteer;
    public BigDouble volunteerUpgradeLevel;
    public BigDouble tree;
    public BigDouble treeUpgradeLevel;

    // Daily Reward Data
    public bool dailyRewardReady;
    public DateTime utcTime;
    public int currentDay;

    //Offline Progress Data
    public bool offlineProgressCheck;


    public Data()
    {
        gems = 0;
        prestige = 1;
        volunteer = 0;
        volunteerUpgradeLevel = 0;
        tree = 0;
        treeUpgradeLevel = 0;

        dailyRewardReady = true;
        currentDay = 0;
        utcTime = DateTime.UtcNow;

        offlineProgressCheck = false;
    }
}
