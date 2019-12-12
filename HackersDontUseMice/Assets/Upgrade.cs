using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
abstract class Upgrade
{
    public float upgradeCostMult = 4;
    public string buttonText = "<upgrade_button_text>";
    public int defaultUpgradeCost = 1;
    public string upgradeName = "<upgrade_name>";
    protected int upgradeCost = 1;
    protected int upgradesBought = 0;
    protected float keystrokeGeneration = 0;
    public Upgrade()
    {
	keystrokeGeneration = 0;
	upgradesBought = 0;
	upgradeCost = defaultUpgradeCost;
    }
    // Public Interface
    public float getKeysPerSecond()
    {
	return keystrokeGeneration * upgradesBought;
    }
    //Purchase Upgrade
    public virtual void buyUpgrade(ref int totalKeystrokes, ref int keyPower)
    {
	if (totalKeystrokes >= upgradeCost)
	{
	    totalKeystrokes -= upgradeCost;
	    upgradesBought++;
	    upgradeCost = Mathf.FloorToInt(upgradeCost * upgradeCostMult);
	}
	Debug.Log(upgradesBought);
    }
    public virtual void tick(ref int totalKeystrokes, ref int keyPower)
    {	buttonText = "Buy 1 " + upgradeName +
	    "\n Cost = " + upgradeCost.ToString();

    }
    public virtual void identify()
    {
	Debug.Log("I am " + upgradeName);
    }
}
