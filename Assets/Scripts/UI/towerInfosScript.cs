using UnityEngine;
using UnityEngine.UI;

public class towerInfosScript : MonoBehaviour {
	
	public towerScript tower;
	public Text damage, cost, range, reload;

	private void Update() 
	{
		damage.text = tower.damage.ToString ();
		cost.text = tower.energy.ToString ();
		range.text = tower.range.ToString ();
		reload.text = tower.fireRate.ToString ();
	}
}
