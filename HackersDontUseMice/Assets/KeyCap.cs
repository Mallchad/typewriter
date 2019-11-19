 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class KeyCap : Upgrade
{
    void Awake()
    {
	upgradeCostMult = 4;
	defaultUpgradeCost = 1;
	upgradeName = "Key Cap";
	keysPerUpgrade = 0;
    }
}
