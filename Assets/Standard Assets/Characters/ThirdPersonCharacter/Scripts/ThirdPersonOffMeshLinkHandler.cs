using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonOffMeshLinkHandler : MonoBehaviour
{
    NavMeshAgent agent;
    ThirdPersonCharacter character;
    Animator animator;

    bool isJumpingLink = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
        animator = GetComponent<Animator>();

        // We will handle traversal ourselves:
        agent.autoTraverseOffMeshLink = false;
    }

    void Update()
    {
        if (!isJumpingLink && agent.isOnOffMeshLink)
        {
            StartCoroutine(HandleJumpLink(agent.currentOffMeshLinkData));
        }
    }

    IEnumerator HandleJumpLink(OffMeshLinkData data)
    {
        isJumpingLink = true;

        // Stop NavMeshAgent movement
        agent.isStopped = true;

        // Force the ThirdPersonCharacter to go into airborne state
        character.ForceAirborneState();

        // Play jump animation
        animator.SetTrigger("Jump");

        Vector3 start = transform.position;
        Vector3 end = data.endPos + Vector3.up * 0.1f;

        float duration = 0.5f;
        float t = 0f;
        float height = 2f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;

            // Parabolic arc
            Vector3 pos = Vector3.Lerp(start, end, t);
            pos.y += Mathf.Sin(Mathf.PI * t) * height;

            transform.position = pos;

            yield return null;
        }

        // Finish link traversal properly
        agent.CompleteOffMeshLink();

        // Restore normal movement
        agent.isStopped = false;

        isJumpingLink = false;
    }
}