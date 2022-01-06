using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class UpgradesManager : MonoBehaviour
{
    public Controller controller;

    public Upgrades clickUpgrade;
    public string clickUpgradeName;
    

    public BigDouble clickUpgradeBaseCost;
    public BigDouble clickUpgradeCostMult;

    public void StartUpgradeManager()
    {
        clickUpgradeName = "Volunteers / Click";
        clickUpgradeBaseCost = 10;
        clickUpgradeCostMult = 1.5;
        UpdateClickUpgradeUI();
    }

    public void UpdateClickUpgradeUI()
    {
        clickUpgrade.LevelText.text = "Level: " + controller.data.clickUpgradeLevel.ToString();
        clickUpgrade.CostText.text = "Cost: " + Cost().ToString("F0") + " Volunteers";
        clickUpgrade.NameText.text = "+1 " + clickUpgradeName;
    }


    public BigDouble Cost() => clickUpgradeBaseCost * BigDouble.Pow(clickUpgradeCostMult, controller.data.clickUpgradeLevel);

    public void BuyUpgrade()
    {
        if (controller.data.volunteers >= Cost())
        {
            controller.data.volunteers -= Cost();
            controller.data.clickUpgradeLevel += 1;
        }
        UpdateClickUpgradeUI();
    }
}
