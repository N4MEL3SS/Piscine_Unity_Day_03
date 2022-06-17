using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverNext : MonoBehaviour
{
	public Text title, score;
	public Text rank;
	public Text buttonText;
	public gameManager manager;
	
	private int energieScore, hpScore, playerScore;
	
	private void Start()
	{
		SetComponent(GetComponent<CanvasGroup> (), 0, false, false);
	}
	
	private void Update()
	{
		if (manager.playerHp <= 0)
			LooseCondition();
		else if (manager.lastWave) 
			WinCondition();
	}

	private void LooseCondition()
	{
		manager.pause (true);
		title.text = "Omae Wa Mou Shindeiru";
		score.text = manager.score.ToString ();
		rank.text = "YOU DIED!!!";
		buttonText.text = "Retry";
		Camera.main.transform.position = new Vector3(0, 0, 0);
		DisplayMenu();
	}

	private void WinCondition()
	{
		GetScore();
		manager.pause (true);
		title.text = "You winner!";
		rank.text = playerScore switch
		{
			10 => "SSS+", 9 => "SSS", 8 => "SS", 7 => "S", 6 => "A", 5 => "B", 4 => "C", 3 => "D", 2 => "E",
			1 => "F", _ => "-"
		};
		score.text = manager.score.ToString();
		buttonText.text = "Next level";
		Camera.main.transform.position = new Vector3(0, 0, 0);
		DisplayMenu();
	}

	private void DisplayMenu()
	{
		SetComponent(GetComponent<CanvasGroup> (), 1, true, true);
	}
	
	private void GetScore() 
	{
		hpScore = manager.playerHp switch {> 19 => 5, 17 => 4, > 13 => 3, > 7 => 2, _ => 1};
		energieScore = manager.playerEnergy switch {> 500 => 5, > 300 => 4, > 250 => 3, > 100 => 2, _ => 1};
		playerScore = energieScore + hpScore;
	}

	private static void SetComponent(CanvasGroup canava, float alpha, bool blocksRaycasts, bool interactable) {
		canava.alpha = alpha;
		canava.blocksRaycasts = blocksRaycasts;
		canava.interactable = interactable;
	}
	
	public void NextOrRetryButton()
	{
		if (manager.playerHp <= 0)
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		else if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		else
			ExitButton();
			
	}

	public void ExitButton()
	{
		SceneManager.LoadScene("ex00");
	}
	
}
