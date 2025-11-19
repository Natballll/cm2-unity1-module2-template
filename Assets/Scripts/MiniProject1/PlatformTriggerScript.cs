using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTriggerScript : MonoBehaviour
{
    private bool isPlayerInsideZone = false;
    public Light lighton;
    public Light lightoff;
    public AudioSource audioSource;
    public AudioClip lightsound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null && lightsound != null)
            {
                audioSource.PlayOneShot(lightsound);
            }
            lighton.enabled = true;
            lightoff.enabled = false;

            isPlayerInsideZone = true;
        }

        
        if (audioSource != null && lightsound != null)
        {
            audioSource.PlayOneShot(lightsound);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInsideZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lighton.enabled = false;
            lightoff.enabled = true;

            isPlayerInsideZone = false;
        }
    }

    public bool PlayerInsideZone()
    {


        return isPlayerInsideZone;
    }
}
