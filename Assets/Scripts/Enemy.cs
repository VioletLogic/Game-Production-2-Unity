using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] float movespeed = 5;
    Rigidbody2D rb;
    Transform target;
    Vector2 move;
    [SerializeField] float desiredDistance = 5;
    [SerializeField] SpriteRenderer enemy;
    [SerializeField] GameObject shotPrefab;
    Animator animator;
    private bool isAttacking;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        tag = "Enemy";
        target = GameObject.Find("Player").transform;
        
        animator = GetComponent<Animator>();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            move = dir;
            // transform.LookAt(target);
            transform.rotation = target.rotation;
        }
        float d = Mathf.Abs(target.position.x - transform.position.x);
        animator.SetFloat("d", d, 1f, Time.deltaTime);
        //target.transform.position.x


    }
    private void FixedUpdate()
    {

        // follow the  player
        float distance = Vector3.Distance(target.position, transform.position);
        //Debug.Log(distance);
        //if (distance < ) {
          
        //    animator.SetBool("isAttacking", true);
          
        ////}
        //else
        //{
        //    animator.SetBool("isAttacking", false);
        //}

  
        if (distance >= desiredDistance)
        {
             
            
            rb.velocity = new Vector2(move.x, 0) * movespeed;
        }
        else
        {
           
            rb.velocity = Vector3.zero;
          
        }
        if (target.position.x  < transform.position.x)
        {
            enemy.flipX = false;
        }else
        {
            enemy.flipX = true;
        }
      
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("uhu");
        //Destroy(other.gameObject);
        Destroy(this.gameObject);
    }

    public void Die()
    {
        animator.SetTrigger("isDie");

        //GetComponent<Collider2D>().enabled = false;
        //GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 1f);
        FindObjectOfType<EnemySpawner>().enemiesCurrentCount -= 1;

        ScoreManager.instance.AddScore(1);
    }
}

