using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private Animator animator;

    private bool isHit = false;

    void Start()
    {

        animator = gameObject.GetComponent<Animator>();


    }
    // Update is called once per frame


    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        //set collide with halfplane, tree and enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //isHit = !isHit;
            Debug.Log("Colldie");
            ScoreManager.instance.TakeDamage(1);
            animator.Play("Player_Hit", 0);
            //animator.SetBool("isHit", isHit);
            //GetComponent<CapsuleCollider2D>().enabled = false;
            yield return new WaitForSeconds(4);
            //GetComponent<CapsuleCollider2D>().enabled = true;
            //isHit = false;
        }

    }
}
