using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager manager;
    public AudioSource JumpSound;
    public AudioSource ShootSound;
    public AudioSource YouWin;
    public AudioSource Lose;
    private void Awake()
    {
        manager = this;
    }
}
