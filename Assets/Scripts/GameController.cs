using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //handles input
    
    public Player player;

    public float playerSpeed;
    public float playerJump;
    [SerializeField] SpriteRenderer pSprite;
    public Rune[] runes;
    
    float cdPassive;
    float cdBasic;
    float cdSpecial;
    float cdUtility;
    float cdUltimate;

    private Animator animator;
    private bool isAttacking = false;
    private bool isJumping = false;
    private bool isRunning = false;
    private bool isHit = false;



    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        runes = GetComponentsInChildren<Rune>();
        //Debug.Log(runes.Length);

        Move();
        Attack();
        
       
        ////Menu
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
            
        //}

        cdPassive -= Time.deltaTime;
        cdBasic -= Time.deltaTime;
        cdSpecial -= Time.deltaTime;
        cdUtility -= Time.deltaTime;
        cdUltimate -= Time.deltaTime;
    }

    void Move()
    {
        player.rigidbody.velocity = new Vector2(0, player.rigidbody.velocity.y);
        //Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            isRunning = !isRunning;
            player.rigidbody.velocity += Vector2.left * playerSpeed;
            pSprite.flipX = true;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            isRunning = !isRunning;
            pSprite.flipX = false;
            player.rigidbody.velocity += Vector2.right * playerSpeed;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = !isJumping;
            player.rigidbody.velocity += Vector2.up * playerJump;
        }
        animator.SetBool("isRunning", isRunning);
    }

    void Attack()
    {
        //Basic
        if (Input.GetKeyDown(KeyCode.Mouse0) && cdBasic <= 0)
        {
            isAttacking = !isAttacking;
            runes[1].ActivateAbility(1);
            cdBasic = runes[1].cooldownBasic;
        }
        //Special
        if (Input.GetKeyDown(KeyCode.Mouse1) && cdSpecial <= 0)
        {
            isAttacking = !isAttacking;
            runes[2].ActivateAbility(2);
            cdSpecial = runes[2].cooldownSpecial;
        }
        //Utility
        if (Input.GetKeyDown(KeyCode.E) && cdUtility <= 0)
        {
            isAttacking = !isAttacking;
            runes[3].ActivateAbility(3);
            cdUtility = runes[3].cooldownUtility;
        }
        //Ultimate
        if (Input.GetKeyDown(KeyCode.R) && cdUltimate <= 0)
        {
            isAttacking = !isAttacking;
            runes[4].ActivateAbility(4);
            cdUltimate = runes[4].cooldownUltimate;
        }
        animator.SetBool("isAttacking", isAttacking);
        isAttacking = false;
    }

    // Player collides with runes/health

    // player hit by enemies


}
