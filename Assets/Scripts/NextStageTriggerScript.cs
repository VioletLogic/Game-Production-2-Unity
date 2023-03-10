using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 newPosition = transform.position + new Vector3(2f, 0f, 0f);

            // Teleport player to new position...
            transform.position = newPosition;
        }
    }
}
