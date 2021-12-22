using UnityEngine;
using TMPro;
using BreakInfinity;


public class Controller : MonoBehaviour
{
    public UpgradesManager upgradeManager;
    public Data data;
    public TMP_Text treeText;
    public TMP_Text treeClickPowerText;

    public BigDouble ClickPower() => 1 + data.clickUpgradeLevel;
    

    public void Start()
    {
        data = new Data();
        upgradeManager.StartUpgradeManager();
    }

    public void Update()
    {
        treeText.text = "Tree Count: " + data.trees.ToString("F0");
        treeClickPowerText.text = "+" + ClickPower() + " Tree / Click";
    }

    public void GenerateTree()
    {
        data.trees += ClickPower();
    }
}
