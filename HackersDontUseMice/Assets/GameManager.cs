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
	GameUpgrades.Add(new ClickBot());
	GameUpgrades.Add(new BotNet());
	UpgradeButtons[0].onClick.AddListener( () => GameUpgrades[0].buyUpgrade(ref totalKeystrokes, ref keyPower));
	UpgradeButtons[1].onClick.AddListener( () => GameUpgrades[1].buyUpgrade(ref totalKeystrokes, ref keyPower));
	UpgradeButtons[2].onClick.AddListener( () => GameUpgrades[2].buyUpgrade(ref totalKeystrokes, ref keyPower));

	for (int i = 0; i < GameUpgrades.Count; ++i)
	{   // Foreach Loop
	    // if (UpgradeButtons.Count < GameUpgrades.Count &&
	    // 	i > UpgradeButtons.Count)
	    //     {
	    // 	UpgradeButtons.Add(gameObject.AddComponent<Button>());
	    // 	UpgradeButtons[i].transform.position = UpgradeButtons[i-1].transform.position
	    // 	    + (Vector3.up * 10);
	    //     }
	    Text ButtonText = UpgradeButtons[i].GetComponentInChildren<Text>();
	    ButtonText.text = GameUpgrades[i].buttonText;
	    Debug.Log(GameUpgrades.Count.ToString());
	    // Bind Upgrade Purchase to Button
	    // UpgradeButtons[i].onClick.AddListener( ()=>GameUpgrades[i].buyUpgrade(ref totalKeystrokes, ref keyPower));
	}
	// resources.GameUpgrades = this.GameUpgrades;
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
    {   // Other Object Ticks
	foreach (Upgrade UniqueUpgrade in GameUpgrades)
	{
	    UniqueUpgrade.tick(ref totalKeystrokes, ref keyPower);
	} // Second Timer
	if (lifetimeTicks - startTicks > gameTickRate)
	{
	    startTicks = lifetimeTicks;
	    second();
	}
	lifetimeTicks++;
	for (int i = 0; i < GameUpgrades.Count; ++i)
	{
	    Text ButtonText = UpgradeButtons[i].GetComponentInChildren<Text>();
	    ButtonText.text = GameUpgrades[i].buttonText;

	}
    }
    void second()
    {	// Keystroke Auto-Generation
	foreach (Upgrade UniqueUpgrade in GameUpgrades)
	{
	    totalKeystrokes += (int)Math.Floor(UniqueUpgrade.getKeysPerSecond() *
					       UniqueUpgrade.getKeysPerSecond());
	}
    }
}
