using Assets.Scripts.Database;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public int maxTimeMin = 5;
    private string url = "http://bounce-off.azurewebsites.net/submitscore";
   // private string url = " https://localhost:44362/submitscore";
   private int maxScore = 0;
   


    public Text UIList;
    public InputField NameField;
    HighScoreVM[] scoreList;
    private float time;


    void Start()
    {
        time = 0.0f;
        maxScore = (maxTimeMin * 60 * 100);
    }

    public void Update()
    {
        time += Time.deltaTime;
    }

    public void SubmitHighScore()
    {
        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, policy) => true;
        var client = new HttpClient();

        //Set
        HighScoreVM newScore = new HighScoreVM
        { Name = NameField.text, Score = Convert.ToInt32((maxScore - (time*100))), Date = DateTime.Now.ToString()};
        var JsonScore = JsonConvert.SerializeObject(newScore);
        var content = new StringContent(JsonScore.ToString(), Encoding.UTF8, "application/json");
        var PostResult = client.PostAsync(url, content).Result;

        //Get
        var jsonResult = PostResult.Content.ReadAsStringAsync().Result;
        Debug.Log(jsonResult);
        scoreList = JsonConvert.DeserializeObject<HighScoreVM[]>(jsonResult);
        UIList.text = returnScore();

    }

    private string returnScore()
    {
        string allScores = string.Empty;

        foreach (var item in scoreList)
        {
            allScores += $"{item.Name}: {item.Score}, Date: {item.Date}{Environment.NewLine}";
        }

        return allScores;
    }
}


