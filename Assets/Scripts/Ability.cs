using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Ability : MonoBehaviour
{
    public Player player;

    public float damage = 1;
    public float duration = 1f;
    public Vector2 direction = Vector2.right;
    public Vector2 offset;
    public float gravaty = 0;

    public string collidesWith;
    public int maxHits = 1;
    public float onHitMultiplyDamage = 1;
    public float onHitMultiplyDuration = 1;
    public float onHitMultiplySpeed = 1;
    public float onHitMultiplyGravity = 1;
    
    public Effect.Type requitesEffect;
    public Effect.Type blockedByEffect;
    public Effect appliesEffect;

    [TextArea(5, 10)]
    public string notes;

    //public Collider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        GetComponent<Rigidbody2D>().velocity = offset;
        tag = "Ability";
        transform.position += new Vector3(offset.x - 0.25f, offset.y, 0);

        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("No Player found in the scene!");
            return;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        duration -= Time.fixedDeltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
        Vector2 pos = transform.position;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (player.isFlipped)
        {
            direction = Vector2.left;
            spriteRenderer.flipX = false; // flip sprite back to normal when facing left
        }
        else
        {
            direction = Vector2.right;
            spriteRenderer.flipX = true; // flip sprite horizontally when facing right
        }
        // get the direction based on the player's facing direction
        if (player.isFlipped)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }
        direction *= 5f;
        transform.position += Time.fixedDeltaTime * new Vector3(direction.x, direction.y, 0);
        direction.y += gravaty * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Entity e = other.gameObject.GetComponent<Entity>();
        if (e != null)
        {
            if (collidesWith.Contains(e.tag))
            {
                Debug.Log("Ability Hit");
                if (!e.HasEffect(blockedByEffect, false))
                {
                    if (e.HasEffect(requitesEffect, true))
                    {
                        if (appliesEffect != null)
                        {
                            Effect effect = Instantiate(appliesEffect, e.gameObject.transform);
                        }
                    }
             
                }

                e.health -= damage;

                damage *= onHitMultiplyDamage;
                duration *= onHitMultiplyDuration;
                direction *= onHitMultiplySpeed;
                gravaty *= onHitMultiplyGravity;
                
                maxHits--;
                if (maxHits <= 0)
                {
                    Destroy(gameObject,1f);
                }
            }
        }
    }
}
