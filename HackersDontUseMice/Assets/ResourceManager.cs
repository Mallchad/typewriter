using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ResourceManager : MonoBehaviour
{
    public int totalKeystrokes;
    List<Upgrade> GameUpgrades;
    public Text TotalKeystrokesText;
    public Button KeystrokeButton;
    int keyPower = 1;
    void Awake()
    {// Add upgrades to List
	    GameUpgrades.Add(new KeyCap());
        //Instantiate Objects
        Instantiate(TotalKeystrokesText);
        Instantiate(KeystrokeButton);
	totalKeystrokes = 0;
	// Assign Buttons
	KeystrokeButton.onClick.AddListener(userClickOnKeystroke);
    }
    public void userClickOnKeystroke()
    {
	totalKeystrokes += keyPower;
    }
    public void tick()
    {
	foreach (Upgrade UniqueUpgrade in GameUpgrades)
	{
	    totalKeystrokes += (int)Math.Floor(UniqueUpgrade.getKeysPerSecond());
	}
    }
    void Update()
    {
	//KeystrokeButton.Te = "SPACEBAR";
	TotalKeystrokesText.text = totalKeystrokes.ToString();
    }
}
