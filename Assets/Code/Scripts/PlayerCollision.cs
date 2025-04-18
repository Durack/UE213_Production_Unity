using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool isShielded = false;

    public GameObject shieldVisual; // Not used anymore
    private ParticleScript particleScript;

    private void Start()
    {
        particleScript = GetComponent<ParticleScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (isShielded)
            {
                Debug.Log("Shield protected from obstacle!");

                // Play damage particles even if shielded
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

            // Delay destroy so particle can play
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
        // Don't show mesh
        isShielded = true;


        Invoke("DeactivateShield", 10f);
    }

    private void DeactivateShield()
    {
        isShielded = false;

    }
}
