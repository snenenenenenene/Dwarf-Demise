using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonClicked : MonoBehaviour
{

    public Button swordButton;
    public Button pickaxeButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ButtonClicked("Sword");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ButtonClicked("Pickaxe");
        }
    }

    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        ColorBlock cb = swordButton.colors;
        cb.normalColor = Color.white;
        swordButton.colors = cb;

        cb = pickaxeButton.colors;
        cb.normalColor = Color.grey;
        pickaxeButton.colors = cb;
    }

    public void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

    public void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void ButtonClicked(string type)
    {
        // toggle the active state of the sword in the player object and disable the pickaxe

        if (type == "Sword")
        {
            player.transform.Find("Sword").gameObject.SetActive(true);
            player.transform.Find("Pickaxe").gameObject.SetActive(false);

            ColorBlock cb = swordButton.colors;
            cb.normalColor = Color.white;
            swordButton.colors = cb;

            cb = pickaxeButton.colors;
            cb.normalColor = Color.grey;
            pickaxeButton.colors = cb;

        }
        else if (type == "Pickaxe")
        {
            player.transform.Find("Sword").gameObject.SetActive(false);
            player.transform.Find("Pickaxe").gameObject.SetActive(true);

            ColorBlock cb = pickaxeButton.colors;
            cb.normalColor = Color.white;
            pickaxeButton.colors = cb;

            cb = swordButton.colors;
            cb.normalColor = Color.grey;
            swordButton.colors = cb;


        }
        else
        {
            Debug.Log("Error: ButtonClicked() called with invalid type");
        }


    }
}
