using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject[] groundTiles; // Array of different ground tiles

    private int sectionSize = 100; // The size of the ground section
    private Transform player; // Reference to the player's transform
    private float lastGeneratedPositionY; // The last generated Y position
    private float generationThreshold = 500.0f; // The distance the player has to move before generating more ground

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastGeneratedPositionY = player.position.y;
        GenerateInitialGround();
    }

    private void Update()
    {
        // Check if the player has moved enough to trigger new ground generation
        if (player.position.y < lastGeneratedPositionY - generationThreshold)
        {
            GenerateGroundSection();
        }
    }

    private void GenerateInitialGround()
    {
        // Instantiate initial ground tiles based on your layout
        // Set their positions and attach them as children of a ground container put them 0.32f apart on every axis
        // Generate a 100 by 100 grid of ground tiles with the top left corner at 50,0,0

        for (int i = -sectionSize; i < 0; i++)
        {
            for (int j = -50; j < 50; j++)
            {
                Vector3 position = new Vector3(j * 0.32f, i * 0.32f, 0);
                if (Random.Range(0, 100) < 20)
                {
                    Instantiate(groundTiles[1], position, Quaternion.identity);
                }
                else if (Random.Range(0, 100) < 10)
                {
                    Instantiate(groundTiles[2], position, Quaternion.identity);
                }
                else if (Random.Range(0, 100) < 5)
                {
                    Instantiate(groundTiles[3], position, Quaternion.identity);
                }
                else
                {
                    Instantiate(groundTiles[0], position, Quaternion.identity);
                }
                lastGeneratedPositionY = -sectionSize * 0.32f;
                // groundTile.transform.parent = transform;


            }
        }
        //  for (int i = 0; i < 10; i++)
        // {
        //     for (int j = 0; j < 100; j++)
        //     {
        //         GameObject groundTile = Instantiate(groundTiles[0], transform);
        //         groundTile.transform.position = new Vector3(j * 0.32f, i * 0.32f, 0);

        //         // GameObject groundTile = Instantiate(groundTiles[0], transform);
        //         // groundTile.transform.position = new Vector3(j * 0.32f, i * 0.32f, 0);
        //     }
        // }


    }

    private void GenerateGroundSection()
    {
        // Instantiate new ground tiles on the y-axis and adjust their positions
        // Update lastGeneratedPositionY

        for (int i = -sectionSize * 2; i < -sectionSize; i++)
        {
            for (int j = -50; j < 50; j++)
            {
                Vector3 position = new Vector3(j * 0.32f, i * 0.32f, 0);
                if (Random.Range(0, 100) < 20)
                {
                    Instantiate(groundTiles[1], position, Quaternion.identity);
                }
                else if (Random.Range(0, 100) < 10)
                {
                    Instantiate(groundTiles[2], position, Quaternion.identity);
                }
                else if (Random.Range(0, 100) < 5)
                {
                    Instantiate(groundTiles[3], position, Quaternion.identity);
                }
                else
                {
                    Instantiate(groundTiles[0], position, Quaternion.identity);
                }

            }
        }




    }
}





