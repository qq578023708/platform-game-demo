using System;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] ParticleSystem pickupVFX;
    [SerializeField]VoidEventChannel eventChannel;
    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        eventChannel.Boardcast();
        SFXPlayer.audioPlayer.PlayOneShot(pickupSFX);
        Instantiate(pickupVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
