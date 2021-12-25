using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticlePainter : MonoBehaviour
{
    public float radiusScaler = 1;
    public float strength = 1;
    public float hardness = 1;

    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        Paintable p = null;
        if(!other.TryGetComponent(out p))
            return;

        float scale = part.main.startSize.constant;
        Color color = part.main.startColor.color;
        
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        for  (int i = 0; i< numCollisionEvents; i++)
        {
            Vector3 pos = collisionEvents[i].intersection;
            float radius = scale * radiusScaler;
            PaintManager.instance.paint(p, pos, radius, hardness, strength, color);
        }
    }
}
