using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    void OnTriggerStay()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
