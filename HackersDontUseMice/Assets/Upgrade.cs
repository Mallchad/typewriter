using UnityEngine;
using UnityEngine.UI;
class Upgrade : MonoBehaviour
{
    // GameObject go = Instantiate(buttonPrefab);
    //  var button = GetComponent<UnityEngine.UI.Button>();
    //button.onClick.AddListener(() => FooOnClick());
    public float upgradeCostMult;
    protected Button UpgradeButton;
    protected Text UpgradeButtonText;
    public int defaultUpgradeCost;
    public string upgradeName = "upgrade_name_placeholder";
    protected int upgradeCost;
    protected int upgradesBought;
    protected float keysPerUpgrade;
    protected float keysPerSecond;
    protected ResourceManager rResources;
    // IEnumerator keyGenerationTick()
    // {
    // 	while(true)
    // 	{
    // 	    yield return WaitForSeconds(1);
    // 	}
    // }
    void Awake()
    {
	Instantiate(UpgradeButton);
	UpgradeButton.transform.position = this.transform.position;
	UpgradeButton.onClick.AddListener(buyUpgrade);
	keysPerSecond = 0;
	upgradesBought = 0;
	upgradeCost = defaultUpgradeCost;
	GameObject Resources = GameObject.Find("Resources");
    rResources = Resources.GetComponent<ResourceManager>();
    }
    // Update is called once per frame
    void Update ()
    {
	UpgradeButtonText.text = "Buy 1 " + upgradeName +
	    "\n Cost = " + upgradeCost.ToString();
    }
    // Public Interface
    public float getKeysPerSecond()
    {
	return keysPerSecond;
    }
    //Purchase Upgrade
    void buyUpgrade()
    {
	if (rResources.totalKeystrokes >= upgradeCost)
	{
	    upgradesBought++;
	    upgradeCost = Mathf.FloorToInt(upgradeCost * upgradeCostMult);
	}
    }
}
