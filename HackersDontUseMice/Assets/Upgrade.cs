using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
class Upgrade
{
    public float upgradeCostMult = 4;
    protected string UpgradeButtonText = "upgrade_button_text";
    public int defaultUpgradeCost = 1;
    public string upgradeName = "<upgrade_name>";
    protected int upgradeCost = 1;
    protected int upgradesBought = 0;
    protected float keysPerUpgrade = 0;
    public float keysPerSecond = 0;
    public int totalKeystrokes = 0;
    public Upgrade()
    {
	keysPerSecond = 0;
	upgradesBought = 0;
	upgradeCost = defaultUpgradeCost;
    }
    // Public Interface
    public float getKeysPerSecond()
    {
	return keysPerSecond;
    }
    //Purchase Upgrade
    public void buyUpgrade()
    {
	if (totalKeystrokes >= upgradeCost)
	{
	    upgradesBought++;
	    upgradeCost = Mathf.FloorToInt(upgradeCost * upgradeCostMult);
	}
	UpgradeButtonText = "Buy 1 " + upgradeName +
	    "\n Cost = " + upgradeCost.ToString();

    }
}
