using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundDetect : MonoBehaviour
{
    [SerializeField]float detectRadius = 0.1f;
    [SerializeField] Collider[] colliders=new Collider[1];
    [SerializeField] LayerMask groundLayer;
    public bool IsGround => Physics.OverlapSphereNonAlloc(transform.position, detectRadius, colliders, groundLayer) != 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
