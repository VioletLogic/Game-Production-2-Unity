using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Entity : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Collider2D collider;

    public float health;
    public Effect[] effectList;
    
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
        //collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        effectList = GetComponents<Effect>();
    }

    public bool HasEffect(Effect.Type effect, bool ifNone)
    {
        //return if an effect of Type exists in children components
        if (effect != Effect.Type.None)
        {
            foreach (var e in effectList)
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
