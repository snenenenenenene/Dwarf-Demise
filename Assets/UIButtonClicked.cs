using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonClicked : MonoBehaviour
{

        public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
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

    public void ButtonClicked(string type)
    {
        // toggle the active state of the sword in the player object and disable the pickaxe

        if (type == "Sword")
        {
            player.transform.Find("Sword").gameObject.SetActive(true);
            player.transform.Find("Pickaxe").gameObject.SetActive(false);
        }
        else if (type == "Pickaxe")
        {
            player.transform.Find("Sword").gameObject.SetActive(false);
            player.transform.Find("Pickaxe").gameObject.SetActive(true);

        } else {
            Debug.Log("Error: ButtonClicked() called with invalid type");
        }


    }
}
