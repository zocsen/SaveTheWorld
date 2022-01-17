using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class UpgradesManager : MonoBehaviour
{
    public Controller controller;

    public Upgrades volunteerUpgrade;
    public string volunteerUpgradeName;
    public BigDouble volunteerUpgradeBaseCost;
    public BigDouble volunteerUpgradeCostMult;

    public Upgrades treeUpgrade;
    public string treeUpgradeName;
    public BigDouble treeUpgradeBaseCost;
    public BigDouble treeUpgradeCostMult;

    public void StartUpgradeManager()
    {
        volunteerUpgradeName = "Volunteers/Click";
        volunteerUpgradeBaseCost = 10;
        volunteerUpgradeCostMult = 1.5;
        //
        treeUpgradeName = "Trees/Sec";
        treeUpgradeBaseCost = 10;
        treeUpgradeCostMult = 1.5;

        // Have to be last
        UpdateClickUpgradeUI();
    }

    public void UpdateClickUpgradeUI()
    {
        volunteerUpgrade.LevelText.text = "Level: " + controller.data.volunteerUpgradeLevel.ToString();
        volunteerUpgrade.NameText.text = "+1 " + volunteerUpgradeName;
        volunteerUpgrade.CostText.text = "Cost: " + VolunteerCost().ToString("F0") + " Volunteers";
        //
        treeUpgrade.LevelText.text = "Level: " + controller.data.treeUpgradeLevel.ToString();
        treeUpgrade.NameText.text = "+1" + treeUpgradeName;
        treeUpgrade.CostText.text = "Cost: " + TreeCost().ToString("F0") + " Volunteers";


    }

    public BigDouble VolunteerCost() => volunteerUpgradeBaseCost * BigDouble.Pow(volunteerUpgradeCostMult, controller.data.volunteerUpgradeLevel);
    public BigDouble TreeCost() => treeUpgradeBaseCost * BigDouble.Pow(treeUpgradeCostMult,controller.data.treeUpgradeLevel);


    public void BuyVolunteerUpgrade()
    {
        if (controller.data.volunteer >= VolunteerCost())
        {
            controller.data.volunteer -= VolunteerCost();
            controller.data.volunteerUpgradeLevel += 1;
        }
        UpdateClickUpgradeUI();
    }
    //
    public void BuyTreeUpgrade()
    {
        if (controller.data.volunteer >= TreeCost())
        {
            controller.data.volunteer -= TreeCost();
            controller.data.treeUpgradeLevel += 1;
        }
        UpdateClickUpgradeUI();
    }
}
