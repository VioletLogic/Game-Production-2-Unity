using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Ability : MonoBehaviour
{
    public string SpriteName;
    public int Damage = 1;
    public int MaxHits = 1;
    public float Duration = 1.0f;
    public Vector2 Direction = Vector2.right;
    public float Gravaty = 0;

    public LayerMask collidesWith;
    
    public Effect.Type RequitesEffect;
    public Effect.Type BlockedByEffect;
    public Effect AppliesEffect;

    [TextArea(5, 10)]
    public string Notes;

    //public Collider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Duration -= Time.fixedDeltaTime;
        if (Duration <= 0)
        {
            Destroy(gameObject);
        }

        transform.position += Time.fixedDeltaTime * new Vector3(Direction.x, Direction.y, 0);
        Direction.y += Gravaty * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Entity e = other.gameObject.GetComponent<Entity>();
        if (e != null)
        {
            if (collidesWith == (collidesWith | (1 << e.gameObject.layer)))
            {
                Debug.Log("Ability Hit");
                if (!e.hasEffect(BlockedByEffect))
                {
                    if (RequitesEffect)
                    Effect effect = Instantiate(AppliesEffect, e.gameObject.transform);
                }
                
                Destroy(other.gameObject);
                MaxHits--;
                if (MaxHits <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
