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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            special.ActivateAbility(special.abilitySpecial);
        }
    }
}
