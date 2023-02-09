using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public enum Type
    {
        None, Burning, Wet, Frozen, Airborne, Stunned, Grounded, Phasing, Regeneration, Corruption 
    }

    public Type type;
    public int level;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
