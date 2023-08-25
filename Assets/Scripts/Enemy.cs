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
        if (collision.gameObject.tag == "Player")
        {
            CharacterInteractionController player = collision.gameObject.GetComponent<CharacterInteractionController>();

            player.health -= damage;
            // push the player back to the direction the enemy is facing
            player.GetComponent<Rigidbody2D>().AddForce(transform.right * 10);

            // play the hurt sound

            AudioClip hurtSound = Resources.Load<AudioClip>("Sound/ouch");
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
