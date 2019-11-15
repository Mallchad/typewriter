using UnityEngine;
using UnityEngine.UI;
public class Upgrade : MonoBehaviour
{
    public float upgradeCostMult;
    public Text UpgradeButtonText;
    public int defaultUpgradeCost;
    public string upgradeName = "upgrade_name_placeholder";
    protected int upgradeCost;
    protected int upgradesBought;
    protected float keysPerUpgrade;
    protected float keysPerSecond;
    // IEnumerator keyGenerationTick()
    // {
    // 	while(true)
    // 	{
    // 	    yield return WaitForSeconds(1);
    // 	}
    // }
    void Start()
    {
	keysPerSecond = 0;
	upgradesBought = 0;
	upgradeCost = defaultUpgradeCost;
    }
    // Update is called once per frame
    void Update ()
    {
	UpgradeButtonText.text = "Buy 1 " + upgradeName +
	    "\n Cost = " + upgradeCost.ToString();
    }
    // Public Interface
	public virtual float getKeysPerSecond()
    {
	return keysPerSecond;
    }
    //Purchase Upgrade
    public float buyUpgrade(int totalKeystrokes)
    {
	if (totalKeystrokes >= upgradeCost)
	{
	    upgradesBought++;
	    upgradeCost = Mathf.FloorToInt(upgradeCost * upgradeCostMult);
	    return upgradeCost;
	}
	else
	    return -1;
    }
}
