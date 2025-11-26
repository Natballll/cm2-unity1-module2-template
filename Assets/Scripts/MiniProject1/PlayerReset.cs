﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform objectPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResetPlayer(other.gameObject);
        }
        else
        {
            ResetObject(other.gameObject);
        }
    }

    public void ResetPlayer(GameObject other)
    {
        other.transform.position = spawnPoint.position;
    }

    public void ResetObject(GameObject other)
    {
        other.transform.position = objectPoint.position;
    }
}