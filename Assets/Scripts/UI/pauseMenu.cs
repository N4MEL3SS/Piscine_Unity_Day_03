using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

	public gameManager manager;
	public GameObject exitConfirmCanvas;
	public GameObject pauseMenuCanvas;
	public GameObject pauseBackground;
	private bool pause = false;
	
	private void Start()
	{
		SetComponent (pauseMenuCanvas.GetComponent<CanvasGroup> (), 0.0f, false, false);
		SetComponent (pauseBackground.GetComponent<CanvasGroup> (), 0.0f, false, false);
		SetComponent (exitConfirmCanvas.GetComponent<CanvasGroup> (), 0.0f, false, false);
	}
	
	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && !pause)
		{
			setPause (true);
			displayMenu ();
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && pause)
		{
			setPause(false);
			hideMenu();
		}
		else if(Input.GetKeyDown(KeyCode.R))
			RetryLevel();
	}

	// Pause Menu
	public void PauseContinueButton() 
	{
		hideMenu ();
	}
	
	public void PauseRetryButton() 
	{
		RetryLevel();
	}

	public void PauseQuitButton() 
	{
		displayExitMenu();
	}

	// Confirmed Button
	public void ConfirmedContinueButton() 
	{
		hideExitMenu ();
	}
	
	private void displayMenu ()
	{
		SetComponent (pauseMenuCanvas.GetComponent<CanvasGroup> (), 1, true, true);
		SetComponent (pauseBackground.GetComponent<CanvasGroup> (), 1, true, true);
		Camera.main.transform.position = new Vector3(0, 0, 0);
	}

	private void displayExitMenu() 
	{
		SetComponent (pauseBackground.GetComponent<CanvasGroup> (), 0f, false, false);
		SetComponent (exitConfirmCanvas.GetComponent<CanvasGroup> (), 1, true, true);
	}

	private void hideMenu()
	{
		setPause (false);
		SetComponent (pauseMenuCanvas.GetComponent<CanvasGroup> (), 0, false, false);
		Camera.main.transform.position = new Vector3(0, 0, -10);
	}

	private void hideExitMenu ()
	{
		Debug.Log ("Hide exit menu");
		SetComponent (exitConfirmCanvas.GetComponent<CanvasGroup> (), 0, false, false);
		displayMenu ();
	}

	public void ConfirmedExitButton () 
	{
		SceneManager.LoadScene ("ex00");
	}
	
	private void setPause(bool isPos)
	{
		pause = isPos;
		manager.pause (isPos);
	}

	private static void SetComponent(CanvasGroup canava, float alpha, bool blocksRaycasts, bool interactable) 
	{
		canava.alpha = alpha;
		canava.blocksRaycasts = blocksRaycasts;
		canava.interactable = interactable;
	}

	private void RetryLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
