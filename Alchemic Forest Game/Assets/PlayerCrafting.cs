﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrafting : MonoBehaviour {

    bool crafting;

    bool bridgeRune, torchRune, axeRune, netRune, shovelRune;

    int bridges;
    // Use this for initialization
    void Start () {
        crafting = false;
        bridgeRune = false;
        torchRune = false;
        axeRune = false;
        netRune = false;
        shovelRune = false;

        bridges = 0;

        Light dimLight = GameObject.FindWithTag("Dim Light").GetComponent<Light>();
        Light torchLight = GameObject.FindWithTag("Torch Light").GetComponent<Light>();

        dimLight.intensity = 1;
        torchLight.intensity = 0;
    }
	
	// Update is called once per frame
	void Update () {

        GameObject player = GameObject.Find("Player");
        PlayerMovement inventory = player.GetComponent<PlayerMovement>(); // !!! change me when inventory moves to own script !!!

        // check that user is on transmutation circle and which recipe to use
        // crafting for bridge
        if (crafting == true && bridgeRune == true && Input.GetKeyDown(KeyCode.Alpha3))
        {

            // check for necessary materials
            if (inventory.logCount >= 3)
            {
                inventory.logCount -= 3;
                inventory.logDisplay.text = inventory.logCount.ToString();

                switch (bridges)
                {
                    case 0:
                        GameObject.FindWithTag("Bridge Cover").SetActive(false);
                        GameObject.FindWithTag("Bridge Cover1").SetActive(false);
                        break;

                    case 1:
                        GameObject.FindWithTag("Bridge Cover2").SetActive(false);
                        GameObject.FindWithTag("Bridge Cover3").SetActive(false);
                        break;

                    case 2:
                        GameObject.FindWithTag("Bridge Cover3").SetActive(false);
                        break;

                    default :
                        break;
                }

                bridges += 1;
            }
        }

        if (crafting == true && torchRune == true && Input.GetKeyDown(KeyCode.Alpha1))
        {

            // check for necessary materials
            if (inventory.logCount >= 1 && inventory.clothCount >= 2)
            {
                inventory.logCount -= 1;
                inventory.clothCount -= 2;
                inventory.logDisplay.text = inventory.logCount.ToString();
                inventory.clothDisplay.text = inventory.clothCount.ToString();

                Light dimLight = GameObject.FindWithTag("Dim Light").GetComponent<Light>();
                Light torchLight = GameObject.FindWithTag("Torch Light").GetComponent<Light>();

                dimLight.intensity = 0;
                torchLight.intensity = 1;

                inventory.torchCount += 1;
                inventory.torchDisplay.text = inventory.torchCount.ToString();
            }
        }

        if (crafting == true && axeRune == true && Input.GetKeyDown(KeyCode.Alpha2))
        {

            // check for necessary materials
            if (inventory.logCount >= 1 && inventory.metalCount >= 2)
            {
                inventory.logCount -= 1;
                inventory.metalCount -= 2;
                inventory.logDisplay.text = inventory.logCount.ToString();
                inventory.metalDisplay.text = inventory.metalCount.ToString();

                inventory.hasAxe = true;
                inventory.axeCount += 1;
                inventory.axeDisplay.text = inventory.axeCount.ToString();
            }
        }

        if (crafting == true && netRune == true && Input.GetKeyDown(KeyCode.Alpha4))
        {

            // check for necessary materials
            if (inventory.logCount >= 2 && inventory.clothCount >= 3)
            {
                inventory.logCount -= 2;
                inventory.clothCount -= 3;
                inventory.logDisplay.text = inventory.logCount.ToString();
                inventory.clothDisplay.text = inventory.clothCount.ToString();

                inventory.hasNet = true;

                inventory.netCount += 1;
                inventory.netDisplay.text = inventory.netCount.ToString();
            }
        }

        if (crafting == true && shovelRune == true && Input.GetKeyDown(KeyCode.Alpha5))
        {

            // check for necessary materials
            if (inventory.logCount >= 2 && inventory.metalCount >= 3)
            {
                inventory.logCount -= 2;
                inventory.metalCount -= 3;
                inventory.logDisplay.text = inventory.logCount.ToString();
                inventory.metalDisplay.text = inventory.metalCount.ToString();

                inventory.hasShovel = true;
                inventory.shovelCount += 1;
                inventory.shovelDisplay.text = inventory.shovelCount.ToString();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Transmutation"))
        {
            crafting = true;
        }//end Transmutation if

        if (other.gameObject.CompareTag("Bridge Rune"))
        {
            bridgeRune = true;
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Torch Rune"))
        {
            torchRune = true;
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Axe Rune"))
        {
            axeRune = true;
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Net Rune"))
        {
            netRune = true;
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Shovel Rune"))
        {
            shovelRune = true;
            other.gameObject.SetActive(false);
        }
    }// end of OnTriggerEnter

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Transmutation"))
        {
            crafting = false;
        }//end Transmutation if
    }// end OnTriggerEnter
}// end PlayerCrafting
