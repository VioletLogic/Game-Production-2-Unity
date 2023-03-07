using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector2 StartVelocity;
    private Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        GetComponent<Rigidbody2D>().velocity = StartVelocity;
        Destroy(gameObject, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemy>();
        enemy?.Die(); // check enemy exits or not, if yes, call Die()
        animator.SetTrigger("hit");
        Destroy(gameObject, 0.2f);
    }
    //Update is called once per frame

}