using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterInteractionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public GameObject player;
    public LayerMask collisionMask;
    public Text scoreText;
    public AudioClip popSound;

    public float raycastDistance = 100f;
    public float raycastOffset = 0f;
    public int score = 0;
    public int health = 100;
    public int maxHealth = 100;
    public int damage = 40;
    public int maxDamage = 100;


    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(0)) // Perform raycast on left mouse button click
        {
            // check if either the sword or pickaxe is active

            if (player.transform.Find("Sword").gameObject.activeSelf)
            {
                // get sword
                Sword sword = player.transform.Find("Sword").gameObject.GetComponent<Sword>();

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 origin = transform.position;

                Vector2 direction = (mousePosition - transform.position).normalized;
                // direction.y += raycastOffset;

                RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, collisionMask);

                if (hit.collider && hit.collider.gameObject.tag == "Enemy")
                {
                    AudioSource.PlayClipAtPoint(popSound, transform.position, 0.2f);

                    Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();

                    enemy.health -= sword.damage;

                    if (enemy.health <= 0)
                    {
                        score += enemy.score;
                        scoreText.text = score.ToString();
                        Destroy(hit.collider.gameObject);

                        // play the pop.mp3 sound

                    }

                    // hit.collider.gameObject.GetComponent<Enemy>().health -= damage;

                    // if (hit.collider.gameObject.GetComponent<Enemy>().health <= 0)
                    // {
                    //     score += hit.collider.gameObject.GetComponent<Enemy>().score;
                    //     scoreText.text = score.ToString();
                    //     // play the pop.mp3 sound

                    // }
                }
            }
            else if (player.transform.Find("Pickaxe").gameObject.activeSelf)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 origin = transform.position;

                Vector2 direction = (mousePosition - transform.position).normalized;
                // direction.y += raycastOffset;

                RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, collisionMask);

                if (hit.collider && hit.collider.gameObject.tag == "Ground")
                {
                    hit.collider.gameObject.GetComponent<Tile>().health -= damage;

                    if (hit.collider.gameObject.GetComponent<Tile>().health <= 0)
                    {
                        score += hit.collider.gameObject.GetComponent<Tile>().score;
                        scoreText.text = score.ToString();
                        // play the pop.mp3 sound at 20% volume
                        AudioSource.PlayClipAtPoint(popSound, transform.position, 0.2f);


                        Destroy(hit.collider.gameObject);
                    }
                }
            }
            else
            {
                Debug.Log("Error: No weapon is active");
            }
        }
    }
}
