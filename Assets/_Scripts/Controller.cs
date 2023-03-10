using UnityEngine;
using TMPro;
using BreakInfinity;
using System.Collections;

public class Controller : MonoBehaviour
{
    public Data data;
    public UpgradesManager upgradeManager;
    public DailyRewardManager daily;
    public OfflineManager offlineManager;

    private bool loadedOfflineProduction = false;

    // Texts
    public TMP_Text mainCurrencyCounterText;
    public TMP_Text gemsText;
    public TMP_Text volunteersText;
    public TMP_Text volunteersClickPowerText;
    public TMP_Text treeCounterText;
    public TMP_Text treeCurrencyGainText;

    // Save Management
    public float SaveTime;
    private const string dataFileName = "PlayerData";
   
    // Production
    public BigDouble MainCurrencyPerSec() => data.treeUpgradeLevel;
    public BigDouble ClickPower() => 1 + data.volunteerUpgradeLevel;
    public BigDouble TreePerSec() => data.treeUpgradeLevel;

    

    public void Start()
    {
        Application.targetFrameRate = 120;

        // Save Management
        data = SaveSystem.SaveExists(dataFileName)
            ? SaveSystem.LoadData<Data>(dataFileName): 
            new Data();
        upgradeManager.StartUpgradeManager();

        // Network Check
        if (Application.internetReachability == NetworkReachability.NotReachable) offlineManager.OpenErrorMessage();
        else
        {
            offlineManager.LoadOfflineProduction();
            loadedOfflineProduction = true;
            daily.StartGetUTCTime();
        }
    }

    public void Update()
    {   
        // Network Check
        if (Application.internetReachability == NetworkReachability.NotReachable) offlineManager.OpenErrorMessage();
        else if (loadedOfflineProduction == false)
        {
            offlineManager.LoadOfflineProduction();
            loadedOfflineProduction = true;
        }
        else if (data.dailyRewardReady == true && Application.internetReachability != NetworkReachability.NotReachable)
        {
            daily.StartGetUTCTime();
        }

        data.mainCurrency += MainCurrencyPerSec() * Time.deltaTime;
        mainCurrencyCounterText.text = data.mainCurrency.ToString("F0");
        gemsText.text = data.gems.ToString("F0");

        volunteersText.text = "Volunteers: " + data.volunteer.ToString("F0");
        volunteersClickPowerText.text = "+" + ClickPower() + " Volunteers / Click";

        treeCounterText.text = "Trees: " + data.treeUpgradeLevel.ToString("F0");
        treeCurrencyGainText.text = "+" + TreePerSec() + " Currency / Second";
        //data.tree += TreePerSec() * Time.deltaTime;
        
        
        // SaveTime
        SaveTime += Time.deltaTime * (1 / Time.timeScale);
        if(SaveTime >= 1)
        {
            SaveSystem.SaveData(data, dataFileName);
            SaveTime = 0;
        } 
    }

    public void GenerateVolunteers()
    {
        data.volunteer += ClickPower();
    }
}
