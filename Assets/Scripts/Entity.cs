using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Entity : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Collider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasEffect(Effect.Type effect, bool ifNone)
    {
        //return if an effect of Type exists in children components
        if (effect != Effect.Type.None)
        {
            Effect[] list = GetComponents<Effect>();
            foreach (var e in list)
            {
                if (e.type == effect)
                {
                    return true;
                }
            }

            return false;
        }
        return ifNone;
    }
}
