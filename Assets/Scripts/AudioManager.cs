using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject Song1, Song2;
    void Start()
    {
        Song1.SetActive(true);
        Song2.SetActive(false);
    }

    public void SwitchSong1()
    {
        Song1.SetActive(true);
        Song2.SetActive(false);
    }

    public void SwitchSong2()
    {
        Song2.SetActive(true);
        Song1.SetActive(false);
    }
}
