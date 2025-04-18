using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [Header("Particles")]
    [SerializeField] public ParticleSystem collectibleParticle; // notes
    [SerializeField] public ParticleSystem dmgParticle;         // sparks
    [SerializeField] public ParticleSystem shieldParticle;      // shield

    public void PlayCollectibleParticle()
    {
        if (collectibleParticle != null)
            collectibleParticle.Play();
    }

    public void PlayDamageParticle()
    {
        if (dmgParticle != null)
            dmgParticle.Play();
    }

    public void PlayShieldParticle()
    {
        if (shieldParticle != null)
            shieldParticle.Play();
    }
}
