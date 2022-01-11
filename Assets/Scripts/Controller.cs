using UnityEngine;
using TMPro;
using BreakInfinity;


public class Controller : MonoBehaviour
{
    public UpgradesManager upgradeManager;
    public Data data;
    public TMP_Text volunteersText;
    public TMP_Text volunteersClickPowerText;
    public TMP_Text treeCounterText;
    public TMP_Text treePerSecText;


    public BigDouble ClickPower() => 1 + data.volunteerUpgradeLevel;
    public BigDouble TreePerSecond() => data.treeUpgradeLevel;


    private const string dataFileName = "PlayerData"; // Save Management

    public void Start()
    {
        Application.targetFrameRate = 120;

        data = SaveSystem.SaveExists(dataFileName)
            ? SaveSystem.LoadData<Data>(dataFileName): 
            new Data();
        upgradeManager.StartUpgradeManager(); // Save Management
    }

    public float SaveTime;
    public void Update()
    {
        
        volunteersText.text = "Volunteers: " + data.volunteer.ToString("F0");
        volunteersClickPowerText.text = "+" + ClickPower() + " Volunteers / Click";

        treeCounterText.text = "Trees: " + data.tree.ToString("F0");
        treePerSecText.text = "+" + TreePerSecond() + " Trees / Second";
        data.tree += TreePerSecond() * Time.deltaTime;
        
        SaveTime += Time.deltaTime * (1 / Time.timeScale);
        if(SaveTime >= 5)
        {
            SaveSystem.SaveData(data, dataFileName);
            SaveTime = 0;
        } // SaveTime

    }

    public void GenerateVolunteers()
    {
        data.volunteer += ClickPower();
    }
}
