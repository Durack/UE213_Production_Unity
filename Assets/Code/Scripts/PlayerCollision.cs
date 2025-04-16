using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool isShielded = false;
    public GameObject shieldVisual; // Drag & drop the shield (child of Car) in Inspector

    //===============================================================================================
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (isShielded)
            {
                Debug.Log("Shield protected from obstacle!");
            }
            else
            {
                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.ResetCombo();
                }

                Debug.Log("Hit obstacle!");
            }

            Destroy(other.gameObject);
        }

        else if (other.CompareTag("ShieldBuff"))
        {
            ActivateShield();
            Destroy(other.gameObject);
        }
    }
    //===============================================================================================

    private void ActivateShield()
    {
        if (shieldVisual != null)
        {
            shieldVisual.GetComponent<MeshRenderer>().enabled = true;
        }

        isShielded = true;
        Debug.Log("Shield activated!");

        Invoke("DeactivateShield", 10f);
    }

    private void DeactivateShield()
    {
        isShielded = false;

        if (shieldVisual != null)
        {
            shieldVisual.GetComponent<MeshRenderer>().enabled = false;
        }

        Debug.Log("Shield deactivated.");
    }
}
