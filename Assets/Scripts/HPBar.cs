using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public GameObject player;
    // textmeshpro object to display the player's health
    public Text HPText;

    public Slider slider;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // set the max value of the HP bar to be the same as the player's health


        slider.maxValue = player.GetComponent<CharacterInteractionController>().maxHealth;

        // set the value of the HP bar to be the same as the player's health

        slider.value = player.GetComponent<CharacterInteractionController>().health;

        // set text of HPText to be the player's health

        HPText.text = player.GetComponent<CharacterInteractionController>().health.ToString();


    }
}
