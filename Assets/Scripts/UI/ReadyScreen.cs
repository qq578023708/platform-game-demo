using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelStartEvent;
    [SerializeField] AudioClip startVoice;

    void LevelStart()
    {
        levelStartEvent.Boardcast();
        GetComponent<Canvas>().enabled = false;
        GetComponent<Animator>().enabled = false;
    }

    void PlayStartVoice()
    {
        SFXPlayer.audioPlayer.PlayOneShot(startVoice);
    }
}
