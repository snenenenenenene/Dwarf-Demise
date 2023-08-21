using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 40;
    public int score = 50;

    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // check if collision is player
        if (collision.gameObject.tag == "Player")
        {
            CharacterInteractionController player = collision.gameObject.GetComponent<CharacterInteractionController>();

            player.health -= damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
