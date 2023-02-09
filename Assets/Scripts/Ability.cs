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

    public bool CollidesWithPlayer;
    public bool CollidesWithPlayerProjectiles;
    public bool CollidesWithEnemies;
    public bool CollidesWithEnemyProjectiles;
    public bool CollidesWithTerrain;
    
    public Effect.Type RequitesEffect;
    public Effect.Type BlockedByEffect;
    public Effect.Type AppliesEffect;

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
        Debug.Log("Ability Hit");
        Destroy(other.gameObject);
        MaxHits--;
        if (MaxHits <= 0)
        {
            Destroy(gameObject);
        }
    }
}
