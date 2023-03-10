using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using System;

[Serializable]
public class Data
{
    // Player Data
    public BigDouble mainCurrency;
    public BigDouble gems;
    public BigDouble prestige;
    public BigDouble volunteer;
    public BigDouble volunteerUpgradeLevel;
    public BigDouble tree;
    public BigDouble treeUpgradeLevel;
    public BigDouble selectiveBinsLevel;

    // Daily Reward Data
    public bool dailyRewardReady;
    public DateTime utcTime;
    public int currentDay;

    //Offline Progress Data
    public bool offlineProgressCheck;


    public Data()
    {
        // Player Data
        mainCurrency = 10;
        gems = 500;
        prestige = 1;
        volunteer = 0;
        volunteerUpgradeLevel = 0;
        tree = 0;
        treeUpgradeLevel = 0;

        //Daily Reward Data
        dailyRewardReady = true;
        currentDay = 0;
        utcTime = DateTime.UtcNow;

        //Offline Progress Data
        offlineProgressCheck = false;
    }
}
