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

    public GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        //gameController = GameObject.FindObjectOfType<GameController>();
        //Debug.Log(FindObjectOfType<GameController>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateAbility(int slot)
    {

        //var projectile = Instantiate(projectilePrefab, // Create fireball prefab when Jump
        //       new Vector3(3, 0) + transform.position, // to avoid collision between Fireball and Blue Dragon need vector3
        //       projectilePrefab.transform.rotation); //to avoid rotaion

        Transform p = transform.parent.GetComponent<GameController>().player.transform;
        switch (slot)
        {
            case 0:


                var projectile = Instantiate(abilityPassive, // Create fireball prefab when Jump
               new Vector2(-1, 0) * transform.position, // to avoid collision between Fireball and Blue Dragon need vector3
               abilityPassive.transform.rotation); //to avoid rotaion



                //Instantiate(abilityPassive, new Vector3(3, 0) + transform.position, p.rotation);
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
