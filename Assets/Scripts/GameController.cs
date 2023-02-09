using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //handles input
    
    public Player player;

    public float playerSpeed;
    public float playerJump;
    
    public Rune slotPassive;
    public Rune slotBasic;
    public Rune slotSpecial;
    public Rune slotUtility;
    public Rune slotUltimate;
    
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            slotBasic.ActivateAbility(1);
        }
        //Special
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            slotBasic.ActivateAbility(2);
        }
        //Utility
        if (Input.GetKeyDown(KeyCode.E))
        {
            slotBasic.ActivateAbility(3);
        }
        //Ultimate
        if (Input.GetKeyDown(KeyCode.R))
        {
            slotBasic.ActivateAbility(4);
        }
        //Interact
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }
        //Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }
}
