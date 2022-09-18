using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public static AudioSource audioPlayer { get; private set; }
    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }
}
