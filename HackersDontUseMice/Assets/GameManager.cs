using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class GameManager : MonoBehaviour
{
    public Text TotalKeystrokesText;
    public Button KeystrokeButton;
    public Button KeycapBuyButton;
    public float gameTickRate = 30;
    double gameTickTimer = 0.016f;
    int lifetimeTicks = 0;
    int startTicks = 0;
    public int totalKeystrokes = 0;
    public int keyPower = 1;
    List<Upgrade> GameUpgrades = new List<Upgrade>();
    public List<Button> UpgradeButtons = new List<Button>();
    void Awake()
    {
	gameTickTimer = (1/gameTickRate);
	// Assign Buttons
	KeystrokeButton.onClick.AddListener(userClickOnKeystroke);
	// Instansiate Objects
	// Add upgrades to List
	GameUpgrades.Add(new KeyCap());
	UpgradeButtons.Add(KeycapBuyButton);
	    for (int i = 0; i < GameUpgrades.Count; i++)
	    {   if (UpgradeButtons.Count < GameUpgrades.Count &&
		    i > UpgradeButtons.Count)
		{
		    UpgradeButtons.Add(gameObject.AddComponent<Button>());
		}
		Debug.Log(GameUpgrades.Count.ToString());
		UpgradeButtons[i].onClick.AddListener(GameUpgrades[i].buyUpgrade);
	    }
	// Resources.GameUpgrades = this.GameUpgrades;
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
    {	// Debug.Log(gameTickTimer.ToString());
	// Debug.Log(Time.deltaTime.ToString());
	// Debug.Log((1/gameTickRate).ToString());
	// Debug.Log(gameTickRate.ToString());
	TotalKeystrokesText.text = totalKeystrokes.ToString();
	// Tick Timer
	gameTickTimer -= Time.deltaTime;
	if (gameTickTimer <= 0)
	{// Time for next tick
	    gameTickTimer = (1/gameTickRate); //Reset timer
	    tick();
	}
    }
    void tick()
    {   // Second Timer
	if (lifetimeTicks - startTicks > gameTickRate)
	{
	    startTicks = lifetimeTicks;
	    second();
	}
	lifetimeTicks++;
    }
    void second()
    {	// Keystroke Auto-Generation
	foreach (Upgrade UniqueUpgrade in GameUpgrades)
	{
	    totalKeystrokes += (int)Math.Floor(UniqueUpgrade.getKeysPerSecond() *
					       UniqueUpgrade.keysPerSecond);
	}
    }
}
