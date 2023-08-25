using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int health = 100;
    public bool isDestructible = true;
    public int score = 20;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // create a switch statement that checks the health of the tile
        // if the health is 0, destroy the tile

        switch (health)
        {
            case 100:
                GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 80:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 60:
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 40:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 20:
                GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
            case 0:
                GetComponent<SpriteRenderer>().color = Color.black;
                break;
            default:
                break;
        }
    }
}

