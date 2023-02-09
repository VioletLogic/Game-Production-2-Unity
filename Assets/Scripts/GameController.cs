using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //handles input
    
    public Player player;

    public float playerSpeed;
    public float playerJump;
    
    public Rune[] runes;
    
    float cdPassive;
    float cdBasic;
    float cdSpecial;
    float cdUtility;
    float cdUltimate;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        runes = GetComponentsInChildren<Rune>();
        //Debug.Log(runes.Length);
        
        player.rigidbody.velocity = new Vector2(0, player.rigidbody.velocity.y);
        //Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.rigidbody.velocity += Vector2.left * playerSpeed;
        }
        //Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.rigidbody.velocity += Vector2.right * playerSpeed;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.rigidbody.velocity += Vector2.up * playerJump;
        }
        //Basic
        if (Input.GetKeyDown(KeyCode.Mouse0) && cdBasic <= 0)
        {
            runes[1].ActivateAbility(1);
            cdBasic = runes[1].cooldownBasic;
        }
        //Special
        if (Input.GetKeyDown(KeyCode.Mouse1) && cdSpecial <= 0)
        {
            runes[2].ActivateAbility(2);
            cdSpecial = runes[2].cooldownSpecial;
        }
        //Utility
        if (Input.GetKeyDown(KeyCode.E) && cdUtility <= 0)
        {
            runes[3].ActivateAbility(3);
            cdUtility = runes[3].cooldownUtility;
        }
        //Ultimate
        if (Input.GetKeyDown(KeyCode.R) && cdUltimate <= 0)
        {
            runes[4].ActivateAbility(4);
            cdUltimate = runes[4].cooldownUltimate;
        }
        //Interact
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }
        //Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }

        cdPassive -= Time.fixedDeltaTime;
        cdBasic -= Time.fixedDeltaTime;
        cdSpecial -= Time.fixedDeltaTime;
        cdUtility -= Time.fixedDeltaTime;
        cdUltimate -= Time.fixedDeltaTime;
    }
}
