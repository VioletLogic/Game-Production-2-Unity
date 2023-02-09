using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class Ability : MonoBehaviour
{
    public string spriteName;
    public int damage = 1;
    public int maxHits = 1;
    public float duration = 1.0f;
    public Vector2 direction = Vector2.right;
    public float gravaty = 0;

    public string collidesWith;
    
    public Effect.Type requitesEffect;
    public Effect.Type blockedByEffect;
    public Effect appliesEffect;

    [TextArea(5, 10)]
    public string notes;

    //public Collider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        tag = "Ability";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        duration -= Time.fixedDeltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }

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
                        Effect effect = Instantiate(appliesEffect, e.gameObject.transform);
                    }
                }
                maxHits--;
                if (maxHits <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
