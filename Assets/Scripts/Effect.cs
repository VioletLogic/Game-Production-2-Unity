using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public enum Type
    {
        None, Burning, Wet, Frozen, Airborne, Stunned, Grounded, Phasing, Regeneration, Corruption 
    }

    public Type type;
    public int level;
    public float expireDuration;
    public bool expireOnHit;
    public Effect.Type expireOnEffect;

    private Entity parent;
    private float health;
    
    // Start is called before the first frame update
    void Start()
    {
        tag = "Effect";
        parent = transform.parent.GetComponent<Entity>();
        health = parent.health;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        expireDuration -= Time.fixedDeltaTime;
        if (expireDuration <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            switch (type)
            {
                case Type.Burning:
                    parent.health -= level * 1.0f * Time.fixedDeltaTime;
                    break;
                case Type.Wet:
                    
                    break;
                case Type.Frozen:
                    
                    break;
                case Type.Airborne:
                    
                    break;
                case Type.Stunned:
                    
                    break;
                case Type.Grounded:
                    
                    break;
                case Type.Phasing:
                    
                    break;
                case Type.Regeneration:
                    
                    break;
                case Type.Corruption:
                    
                    break;
            }
        }
        //after expire check to ensure mutual canceling
        if (parent.HasEffect(expireOnEffect, false))
        {
            expireDuration = 0;
        }

        if (expireOnHit && health != parent.health)
        {
            expireDuration = 0;
        }
    }
}
