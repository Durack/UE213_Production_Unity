using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool isShielded = false;

    public GameObject shieldVisual; // Not used anymore for visuals
    private ParticleScript particleScript;

    private void Start()
    {
        // Get the reference once
        particleScript = GetComponent<ParticleScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (isShielded)
            {
                Debug.Log("Shield protected from obstacle!");

                // Play damage particles even if shielded (optional)
                particleScript?.PlayDamageParticle();
            }
            else
            {
                // Play damage sparks
                particleScript?.PlayDamageParticle();

                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.ResetCombo();
                }

                Debug.Log("Hit obstacle!");
            }

            // Delay destroy so particle can play (optional: tweak delay to match particle)
            Destroy(other.gameObject, 0.1f);
        }

        else if (other.CompareTag("ShieldBuff"))
        {
            // Play shield particle
            particleScript?.PlayShieldParticle();

            ActivateShield();
            Destroy(other.gameObject, 0.1f);
        }
    }

    private void ActivateShield()
    {
        // Don't show mesh, just activate effect
        isShielded = true;
        Debug.Log("Shield activated!");

        Invoke("DeactivateShield", 10f);
    }

    private void DeactivateShield()
    {
        isShielded = false;
        Debug.Log("Shield deactivated.");
    }
}
