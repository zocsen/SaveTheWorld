using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class OfflineManager : MonoBehaviour
{
    public Controller controller;

    public GameObject offlinePopup;
    public GameObject errorPanel;

    public TMP_Text timeAwayText;
    public TMP_Text moneyGainedText;

    public UTCTime utcTime;
    public class UTCTime
    {
        public string dateTime;
    }

    public DateTime tempDateTime;

    public void Start()
    {
        StartCoroutine(Timer(5)); // Gets UTC time every x sec
    }

    public async void LoadOfflineProduction()
    {
        if (PlayerPrefs.HasKey("Last_Login"))
        {
            long tempOfflineTime = Convert.ToInt64(PlayerPrefs.GetString("Last_Login"));
            var lastLogin = DateTime.FromBinary(tempOfflineTime);
            var currentTime = await AwaitGetUTCTime();
            var difference = currentTime.Subtract(lastLogin);
            var rawTime = (float)difference.TotalSeconds;

            offlinePopup.gameObject.SetActive(true);
            TimeSpan timer = TimeSpan.FromSeconds(rawTime);
                                                                                                                
            if (timer.Days != 0)
            {
                timeAwayText.text = string.Format("You were away for\n {0} Days {1} Hours {2} Minutes {3} Seconds", timer.Days, timer.Hours, timer.Minutes, timer.Seconds);
            }
            else if (timer.Hours != 0)
            {
                timeAwayText.text = string.Format("You were away for\n {0} Hours {1} Minutes {2} Seconds", timer.Hours, timer.Minutes, timer.Seconds);
            }
            else if(timer.Minutes != 0)
            {
                timeAwayText.text = string.Format("You were away for\n {0} Minutes {1} Seconds", timer.Minutes, timer.Seconds);
            }
            else timeAwayText.text = string.Format("You were away for\n {0} Seconds", timer.Seconds);
            
            moneyGainedText.text = "+" + (int)timer.TotalSeconds * controller.data.treeUpgradeLevel + " Tree";
            controller.data.tree += (int)timer.TotalSeconds * controller.data.treeUpgradeLevel;
        }
    }

    public async Task<DateTime> AwaitGetUTCTime()
    {
        StartCoroutine(GetUTCTime());
        await Task.Delay(1000);
        return tempDateTime;
        
    }

    public IEnumerator GetUTCTime()
    {
        var request = UnityWebRequest.Get("https://timeapi.io/api/Time/current/zone?timeZone=Europe/Amsterdam");
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError) yield break;
        var json = request.downloadHandler.text;
        utcTime = JsonUtility.FromJson<UTCTime>(json);
        tempDateTime = Convert.ToDateTime(utcTime.dateTime);
        Debug.Log(tempDateTime);

        if (tempDateTime.Year != DateTime.Now.Year)
        {
            StartCoroutine(GetUTCTime());
        }
        else
        {
            PlayerPrefs.SetString("Last_Login", tempDateTime.ToBinary().ToString());
        }
    }

    public void OpenErrorMessage()
    {
        errorPanel.gameObject.SetActive(true);
    }

    public void CloseErrorMessage()
    {
        errorPanel.gameObject.SetActive(false);
    }

    public void CloseOffline()
    {
        offlinePopup.gameObject.SetActive(false);
    }

    private IEnumerator Timer(float sec)
    {
        yield return new WaitForSeconds(sec);
        StartCoroutine(GetUTCTime());
        StartCoroutine(Timer(sec));
    }
}
