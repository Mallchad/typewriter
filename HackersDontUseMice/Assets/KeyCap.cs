using UnityEngine;

class KeyCap : Upgrade
{
    public KeyCap()
    {
	upgradeCostMult = 4;
	defaultUpgradeCost = 1;
	upgradeName = "Keycap";
	keystrokeGeneration = 0;
    }
    public override void buyUpgrade(ref int totalKeystrokes, ref int keyPower)
    {
    	if (totalKeystrokes >= upgradeCost)
    	{   // User Can Afford Upgrade
    	    totalKeystrokes -= upgradeCost;
    	    upgradesBought++;
    	    upgradeCost = Mathf.FloorToInt(upgradeCost * upgradeCostMult);
    	    keyPower = upgradesBought;
    	}
    }
}
