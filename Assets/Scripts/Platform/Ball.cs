using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.OnDeath();
        }
    }
}
