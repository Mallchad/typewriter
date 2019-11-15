 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCap : Upgrade, MonoBehaviour
{
    KeyCap()
    {
	upgradeCostMult = 4;
	defaultUpgradeCost = 1;
	upgradeName = "Key Cap";
	keysPerUpgrade = 0;
    }
}
