using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    public int level;
    
    public Ability abilityPassive;
    public float  cooldownPassive;
    public Ability abilityBasic;
    public float  cooldownBasic;
    public Ability abilitySpecial;
    public float  cooldownSpecial;
    public Ability abilityUtility;
    public float  cooldownUtility;
    public Ability abilityUltimate;
    public float  cooldownUltimate;

    private GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateAbility(Ability ability)
    {
        Transform p = gameController.player.transform;
        Instantiate(ability, p.position, p.rotation);
    }
    
}
