using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleType type;
    public float heightOffset;
    public Int32 beat;
    public float offset;

    public Vector3 rotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

#if UNITY_EDITOR
    private void OnValidate() => UnityEditor.EditorApplication.delayCall += _OnValidate;

    private void _OnValidate()
    {
        UnityEditor.EditorApplication.delayCall -= _OnValidate;
        if (this == null) return;

        if (transform.parent != null)
        {
            CollectibleCreator creator = transform.parent.GetComponent<CollectibleCreator>();
            if (creator != null)
            {
                creator.updateCollectible(this);
            }
        }
    }
#endif

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        // Play particle effect on player
        ParticleScript particleScript = other.GetComponent<ParticleScript>();
        if (particleScript != null)
        {
            particleScript.PlayCollectibleParticle();
        }

        // Add score
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(1);
        }

        // Destroy collectible
        Destroy(gameObject);
    }
}

}


public enum CollectibleType { 
    Cube,
    MusicNote1,
    MusicNote2,
    MusicNote3,
    MusicNote4

};
