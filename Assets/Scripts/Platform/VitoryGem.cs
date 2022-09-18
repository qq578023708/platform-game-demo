using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitoryGem : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] ParticleSystem pickupVFX;
    [SerializeField] VoidEventChannel levelClearEvent;
    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        SFXPlayer.audioPlayer.PlayOneShot(pickupSFX);
        Instantiate(pickupVFX, transform.position, Quaternion.identity);
        levelClearEvent.Boardcast();
        Destroy(gameObject);
    }
}
