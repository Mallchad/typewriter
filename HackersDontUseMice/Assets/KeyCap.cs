
class KeyCap : Upgrade
{
    public KeyCap()
    {
	upgradeCostMult = 4;
	defaultUpgradeCost = 1;
	upgradeName = "Keycap";
	keysPerUpgrade = 0;
    }
    public void buyUpgrade()
    {
	if (totalkeystrokes >= upgradeCost)
	{
	    upgradesBought++;
	    upgradeCost = Mathf.FloorToInt(UpgradeCost * UpgradeCostmult);
	}
    }
}
