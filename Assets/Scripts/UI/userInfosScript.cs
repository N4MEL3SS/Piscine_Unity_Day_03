using UnityEngine;
using UnityEngine.UI;

public class userInfosScript : MonoBehaviour
{
	public gameManager manager;
	public Text userHp, userEnergy;
	
	void Update () {
		var playerHP = manager.playerHp;
		if (playerHP < 0)
			playerHP = 0;
		userHp.text = $"{playerHP} HP";
		userEnergy.text = manager.playerEnergy.ToString();
	}
}
