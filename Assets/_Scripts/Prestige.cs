using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prestige : MonoBehaviour
{
    public Controller controller;
    public UpgradesManager upgradesManager;

    public void ResetProgress()
    {
        controller.data.gems = 0;

        controller.data.currentDay = 0;
        controller.data.utcTime = DateTime.UtcNow;
        controller.data.dailyRewardReady = true;

        controller.data.volunteer = 0;
        controller.data.volunteerUpgradeLevel = 0;
        controller.data.tree = 0;
        controller.data.treeUpgradeLevel = 0;
        controller.data.prestige = 0;

        // Have to be last
        upgradesManager.StartUpgradeManager();
    }

    public void PrestigeProgress()
    {
        controller.data.volunteer = 0;
        controller.data.volunteerUpgradeLevel = 0;
        controller.data.tree = 0;
        controller.data.treeUpgradeLevel = 0;
        controller.data.prestige += 1;

        // Have to be last
        upgradesManager.StartUpgradeManager();
    }
}
