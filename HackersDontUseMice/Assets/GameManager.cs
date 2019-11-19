using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
class GameManager : MonoBehaviour 
{
    public Text TotalKeystrokesText;
    public Button KeystrokeButton;
    public ResourceManager Resources;
    public float gameTickRate;
    float gameTickTimer;

    void Awake()
    {
	Instantiate(Resources);
	Resources.TotalKeystrokesText = this.TotalKeystrokesText;
	Resources.KeystrokeButton = this.KeystrokeButton;
    }
    //Adds keystrokes to total
    // Use this for initialization
    void Start ()
    {}
    // Update is called once per frame
    void Update ()
    {
	gameTickTimer += Time.deltaTime;
	if (gameTickTimer <= 0)
	{// Time for next tick
	    gameTickTimer = 1/gameTickRate; //Reset timer
	    Resources.tick();
	}
    }
}
