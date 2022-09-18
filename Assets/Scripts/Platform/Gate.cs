using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] VoidEventChannel eventChannel;

    private void OnEnable()
    {
        eventChannel.AddListener(Open);
    }

    private void OnDisable()
    {
        eventChannel.removeListener(Open);
    }
    void Open()
    {
        Destroy(gameObject);
    }
}
