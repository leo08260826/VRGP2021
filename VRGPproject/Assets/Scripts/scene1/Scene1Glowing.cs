using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Glowing : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip glowSound;
    public float speed = 1f;
    public Glow [] glowObjs;

    void Start() {
        if (TryGetComponent<AudioSource>(out audioSource)) {
            audioSource.loop = false;
            audioSource.spatialBlend = 1f;
            audioSource.pitch = 2f;
            audioSource.volume = 0.3f;
            audioSource.clip = glowSound;
        }
    }
    void Update()
    {
        float rad = Time.realtimeSinceStartup*speed;
        float timeArg = Mathf.Abs(Mathf.Sin(rad));
        if ( audioSource != null
            &&(rad % Mathf.PI) >= (Mathf.PI * 0.98) 
            && (rad % Mathf.PI) <= Mathf.PI 
            && !audioSource.isPlaying
        ) {
            audioSource.Play();
        }
        for(int i=0; i<glowObjs.Length; i++)
        {
            glowObjs[i].glowStr = timeArg;
        }
    }
}
