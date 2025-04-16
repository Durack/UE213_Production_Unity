
using UnityEngine;

public class MissTrigger : MonoBehaviour
{
    //===============================================================================================
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            // Lower combo by 0.2, but clamp it to a minimum of 1.0
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.DecreaseCombo();
            }

            // Destroy the collectible
            Destroy(other.gameObject);
        }
    }
    //===============================================================================================
}
