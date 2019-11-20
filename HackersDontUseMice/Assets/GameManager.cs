using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class GameManager : MonoBehaviour
{
    public Text TotalKeystrokesText;
    public Button KeystrokeButton;
    public ResourceManager Resources;
    public float gameTickRate;
    float gameTickTimer;
    public int totalKeystrokes;
    public int keyPower = 1;
    List<Upgrade> GameUpgrades;
    void Awake()
    {// Add upgrades to List
	GameUpgrades.Add(new KeyCap());
	// Assign Buttons
	KeystrokeButton.onClick.AddListener(userClickOnKeystroke);
	// Instansiate Objects
	foreach (Upgrade UniqueUpgrade in GameUpgrades)
	{
	    Instantiate(UniqueUpgrade.UpgradeButton);
	    // UniqueUpgrade.UpgradeButton.transform.position = Vector3(0,0,0);
	    UniqueUpgrade.UpgradeButton.onClick.AddListener(UniqueUpgrade.buyUpgrade);
	}
	Instantiate(Resources);
	gameTickRate = 60;
	gameTickTimer = 1/gameTickRate;
    }
    //Adds keystrokes to total
    public void userClickOnKeystroke()
    {
	totalKeystrokes += keyPower;
    }
    // Use this for initialization
    void Start ()
    {}
    // Update is called once per frame
    void Update ()
    {
	TotalKeystrokesText.text = totalKeystrokes.ToString();
	// Tick
	gameTickTimer -= Time.deltaTime;
	if (gameTickTimer <= 0)
	{// Time for next tick
	    gameTickTimer = 1/gameTickRate; //Reset timer
	    tick();
	    Resources.tick();
	}
    }
    void tick()
    {
	Resources.totalKeystrokes = totalKeystrokes;
	foreach (Upgrade UniqueUpgrade in GameUpgrades)
	{
	    totalKeystrokes += (int)Math.Floor(UniqueUpgrade.getKeysPerSecond());
	}
    }
}
