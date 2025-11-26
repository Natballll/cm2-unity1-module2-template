using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class Torch : MonoBehaviour
{
    public KeyCode torchKey = KeyCode.E;

    public Light torch;
    void Start()
    {
        torch.enabled = false;
    }
    void Update()
    {
        if (Input.GetKey(torchKey))
        {
            torch.enabled = true;
        }
        else
        {
            torch.enabled = false;
        }
    }
}
