using UnityEngine;

public class KnockbackReceiver : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float upwardModifier = 0f;   // optional vertical lift

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Apply knockback to this object.
    /// </summary>
    /// <param name="direction">Direction FROM the shooter TOWARD the target.</param>
    /// <param name="hitPoint">World position where the bullet hit.</param>
    public void ApplyKnockback(Vector3 direction, Vector3 hitPoint)
    {
        if (rb == null) return;

        // Normalize direction
        Vector3 forceDir = direction.normalized;

        // Optional upward force
        forceDir.y += upwardModifier;

        // Apply knockback as an impulse
        rb.AddForceAtPosition(forceDir * knockbackForce, hitPoint, ForceMode.Impulse);
    }
}
