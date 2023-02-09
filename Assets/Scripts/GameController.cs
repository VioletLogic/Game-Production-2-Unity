using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //handles input
    
    public Player player;
    
    public Rune passive;
    public Rune basic;
    public Rune special;
    public Rune utility;
    public Rune ultimate;

    private float cooldownPassive;
    private float cooldownBasic;
    private float cooldownSpecial;
    private float cooldownUtility;
    private float cooldownUltimate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Left
        bool keyLeft = Input.GetKeyDown(KeyCode.A);
        //Right
        bool keyRight = Input.GetKeyDown(KeyCode.D);
        //Up
        bool keyUp = Input.GetKeyDown(KeyCode.W);
        //Down
        bool keyDown = Input.GetKeyDown(KeyCode.S);
        //Jump
        bool keyJump = Input.GetKeyDown(KeyCode.Space);
        //Basic attack
        bool keyBasic = Input.GetKeyDown(KeyCode.Mouse0);
        //Special attack
        bool keySpecial = Input.GetKeyDown(KeyCode.Mouse0);
        //Utility ability
        bool keyUtility = Input.GetKeyDown(KeyCode.E);
        //Ultimate ability
        bool keyUltimate = Input.GetKeyDown(KeyCode.R);
        //Interact
        bool keyInteract = Input.GetKeyDown(KeyCode.Q);
        //Menu
        bool keyMenu = Input.GetKeyDown(KeyCode.Escape);

        if (keyLeft && !keyRight)
        {
            player.moveLeft();
        }
        
        if (cooldownBasic <= 0 && basic != null && keyBasic)
        {
            basic.ActivateAbility(basic.abilityBasic);
            cooldownBasic = basic.cooldownBasic;
        }
        if (cooldownSpecial <= 0 && special != null && keySpecial)
        {
            special.ActivateAbility(special.abilitySpecial);
            cooldownSpecial = special.cooldownSpecial;
        }
        if (cooldownUtility <= 0 && utility != null && keyUtility)
        {
            utility.ActivateAbility(utility.abilityUtility);
            cooldownUtility = utility.cooldownUtility;
        }
        if (cooldownUltimate <= 0 && ultimate != null && keyUltimate)
        {
            ultimate.ActivateAbility(ultimate.abilityUltimate);
            cooldownUltimate = ultimate.cooldownUltimate;
        }
        cooldownPassive -= Time.fixedDeltaTime;
        cooldownBasic -= Time.fixedDeltaTime;
        cooldownSpecial -= Time.fixedDeltaTime;
        cooldownUtility -= Time.fixedDeltaTime;
        cooldownUltimate -= Time.fixedDeltaTime;
    }
}
