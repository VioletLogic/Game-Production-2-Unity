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

    public void ActivateAbility(int slot)
    {
        Transform p = gameController.player.transform;
        switch (slot)
        {
            case 0:
                Instantiate(abilityPassive, p.position, p.rotation);
                break;
            case 1:
                Instantiate(abilityBasic, p.position, p.rotation);
                break;
            case 2:
                Instantiate(abilitySpecial, p.position, p.rotation);
                break;
            case 3:
                Instantiate(abilityUtility, p.position, p.rotation);
                break;
            case 4:
                Instantiate(abilityUltimate, p.position, p.rotation);
                break;
        }
    }
    
}
