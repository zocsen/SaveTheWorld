using UnityEngine;
using TMPro;
using BreakInfinity;


public class Controller : MonoBehaviour
{
    public UpgradesManager upgradeManager;
    public Data data;
    public TMP_Text volunteersText;
    public TMP_Text volunteersClickPowerText;

    public BigDouble ClickPower() => 1 + data.clickUpgradeLevel;
    

    public void Start()
    {
        Application.targetFrameRate = 120;

        data = new Data();
        upgradeManager.StartUpgradeManager();
    }

    public void Update()
    {
        volunteersText.text = "Volunteers: " + data.volunteers.ToString("F0");
        volunteersClickPowerText.text = "+" + ClickPower() + " Volunteers / Click";
    }

    public void GenerateVolunteers()
    {
        data.volunteers += ClickPower();
    }
}
