using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public TimeSpan score;
    public string nickName;
    private string url = "https://localhost:44362/";


    private InputField playerName;

    void Start()
    {
        
    }

    public void SubmitHighScore()
    {
        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, policy) => true;
        var client = new HttpClient();
        var result = client.GetStringAsync("https://localhost:44362/submitscore").Result;
        //var result = client.GetStringAsync("https://www.google.se/").Result;
        var i = result.Length;

        Debug.Log($"{i}");



    }
}
