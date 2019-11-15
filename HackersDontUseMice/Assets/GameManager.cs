using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class GameManager : MonoBehaviour 
{
    public Text TotalKeystrokesText;
    int totalKeystrokes;
    float secondTimer;
    float keystrokesPerSecond;
    List<Upgrade> avalibleUpgrades = new List<Upgrade>();
    GameManager()
    {
	keystrokesPerSecond = 0;
	secondTimer = 1;
	totalKeystrokes  = 0;
    }
    //Adds keystrokes to total
    public void userClickOnKeystroke()
    {
	int keyPower = 1;
	totalKeystrokes += keyPower;
    }
    // Use this for initialization
    void Start ()
    {
    }
    void keystrokeGenerationTick()
    {
	foreach (Upgrade upgrade in avalibleUpgrades)
	{
	}
    }
    // Update is called once per frame
    void Update ()
    {
	secondTimer += Time.deltaTime;
	if (secondTimer <= 0)
	{
	    keystrokeGenerationTick();
	    secondTimer = 1f;
	}
	TotalKeystrokesText.text = totalKeystrokes.ToString();
    }
}
