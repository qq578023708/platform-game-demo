using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField]float rebrithTime = 3f;
    WaitForSeconds rebrithWaitSecond;
    new BoxCollider collider;
    MeshRenderer mr;
    [SerializeField]AudioClip pickupSFX;
    [SerializeField] ParticleSystem pickupVFX;
    private void Awake()
    {
        rebrithWaitSecond = new WaitForSeconds(rebrithTime);
        collider = GetComponent<BoxCollider>();
        mr=GetComponentInChildren<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.CanAirJump = true;
            collider.enabled = false;
            mr.enabled = false;
            SFXPlayer.audioPlayer.PlayOneShot(pickupSFX);
            Instantiate(pickupVFX,transform.position,Quaternion.identity);
            StartCoroutine(Rebrith());
        }
    }

    IEnumerator  Rebrith()
    {
        yield return rebrithWaitSecond;
        collider.enabled = true;
        mr.enabled = true;
    }
}
