using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTree : MonoBehaviour
{
    public float Speed = 10f;

    //origional position will be vector2(x = 15, y = range(-5,5)
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);

        if (transform.position.x < -20)
        {

            transform.position += new Vector3(30, 0, 0); //Vector3.right * 30;
            ShowRandomSprite();
            //enemy?.Respawn();


        }
    }
    private void ShowRandomSprite()
    {
        int index = UnityEngine.Random.Range(0, 3);
        int childCount = transform.childCount; //transform.childCount helps to count how many children in a object parents
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i); // get child 
            child.gameObject.SetActive(index == i); //set active to activate the child object
        }
    }
    private void OnEnable()
    {
        ShowRandomSprite();
    }
}
