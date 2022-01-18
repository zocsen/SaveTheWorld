using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DailyRewardManager : MonoBehaviour
{
    public Controller controller;

    public DateTime tempDateTime;
    public float UTCTimer;

    public GameObject dailyReward;
    public GameObject dailyRewardClaimed;
    public Text[] rewardText = new Text[7];
    public Image[] rewardButton = new Image[7];
    public int[] rewardPercents;
    public Text rewardClaimText;

    public bool UTCTimeChecked;

    public TMP_Text timeAwayText;
    public TMP_Text moneyGainedText;

    public UTCTime utcTime;
    public class UTCTime
    {
        public string dateTime;
    }

    public void StartGetUTCTime()
  {
        var data = controller.data;

        StartCoroutine(GetUTCTime());
        if (data.dailyRewardReady == false)
        {
            CloseRewards();
        }
        else OpenRewards();
        rewardPercents = new[] { 1, 2, 3, 4, 5, 10, 25 };
    }

    public void Update()
    {
        var data = controller.data;
        if (dailyReward.gameObject.activeSelf)
            for(var i = 0; i < 7; i++)
            {
                //rewardText[i].text = i < data.currentDay ? "Claimed" : $"+{Method.NotationMethod((controller.data.volunteer + 100) * ((float)rewardPercents[i] / 100), "F2")} Volunteers";
                rewardButton[i].color = i < data.currentDay ? Color.green : Color.white;
            }
        UTCTimer += Time.deltaTime;
        if (UTCTimer < 60) return;
        UTCTimer = 0;
        StartCoroutine(GetUTCTime());
    }

    public void Claim(int id)
    {
        var data = controller.data;
        if (data.dailyRewardReady & id <= data.currentDay)
        {
            data.gems += (data.gems + 100) * ((float)rewardPercents[id] / 100);
            data.currentDay++;
            data.dailyRewardReady = false;
            //dailyRewardClaimed.gameObject.SetActive(true);
            data.utcTime = tempDateTime;
            //rewardClaimText.text = $"+{Methods.NotationMethod((data.gems + 100) * ((float)rewardPercents[id] / 100), "F2")} Gems";
        }
    }

    public void OpenRewards()
    {
        dailyReward.gameObject.SetActive(true);
    }

    public void CloseRewards()
    {
       // dailyRewardClaimed.gameObject.SetActive(false);
        dailyReward.gameObject.SetActive(false);
    }

    public void ToggleRewards()
    {
        dailyReward.gameObject.SetActive(!dailyReward.gameObject.activeSelf);
    }

    public IEnumerator GetUTCTime()
    {
        var data = controller.data;
        var request = UnityWebRequest.Get("https://timeapi.io/api/Time/current/zone?timeZone=Europe/Amsterdam");
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.ConnectionError) yield break;
        // if (request.isHttpError || request.isNetworkError) yield break;
        var json = request.downloadHandler.text;
        utcTime = JsonUtility.FromJson<UTCTime>(json);
        tempDateTime = Convert.ToDateTime(utcTime.dateTime);
        
        if ((data.utcTime.Day != tempDateTime.Day || data.utcTime.Month != tempDateTime.Month || data.utcTime.Year != tempDateTime.Year) && !data.dailyRewardReady)
        {
            data.dailyRewardReady = true;
            dailyReward.gameObject.SetActive(true);
            if (data.currentDay >= 7)
                data.currentDay = 0;
        }
    }
}
