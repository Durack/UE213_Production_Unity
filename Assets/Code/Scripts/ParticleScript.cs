using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField] public ParticleSystem particle;

    public void PlayParticle()
    {
        if (particle != null)
        {
            particle.Play();
        }
    }
}
