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
    
    //Movement
    public float speed;
    public float jump;
    public float moveVelocity;

    //Grounded
    bool grounded = true;
    
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
        
        rigidbody.velocity = new Vector2(moveVelocity, rigidbody.velocity.y);
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

    public void moveLeft()
    {
        rigidbody.AddForce(Vector2.left * speed);
    }
    public void moveRight()
    {
        rigidbody.AddForce(Vector2.right * speed);
    }

    public void moveJump()
    {
        rigidbody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    }
    
    //Check if Grounded
    void OnTriggerEnter2D()
    {
        grounded = true;
    }
    void OnTriggerExit2D()
    {
        grounded = false;
    }
}
