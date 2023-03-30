using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float Speed = 20f;

    //origional position will be vector2(x = 15, y = range(-5,5)

    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World );

        if(transform.position.x < -20)
        {

            transform.position += new Vector3(30, 0, 0); //Vector3.right * 30;
            //enemy?.Respawn();

        }
    }

}
