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
    private string url = "https://localhost:44362/submitscore";


    public Text UIList;
    public InputField NameField;
    HighScoreVM[] scoreList;
    int score = 5;


    void Start()
    {
    
    }

    public void SubmitHighScore()
    {
        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, policy) => true;
        var client = new HttpClient();
        //var GetResult = client.GetStringAsync(url).Result;

        //Set
        HighScoreVM newScore = new HighScoreVM { Name = NameField.text, Score = score, Date = DateTime.Now.ToString()};
        var JsonScore = JsonConvert.SerializeObject(newScore);
        var content = new StringContent(JsonScore.ToString(), Encoding.UTF8, "application/json");

        Debug.Log(content);
        var PostResult = client.PostAsync(url, content).Result;
        //Debug.Log(PostResult);

        //Get
        var jsonResult = PostResult.Content.ReadAsStringAsync().Result;
        scoreList = JsonConvert.DeserializeObject<HighScoreVM[]>(jsonResult);
        UIList.text = returnScore();

    }

    private string returnScore()
    {
        string allScores = string.Empty;

        foreach (var item in scoreList)
        {
            allScores += $"{item.Name}: {item.Score}{Environment.NewLine}";
        }

        return allScores;
    }
}


