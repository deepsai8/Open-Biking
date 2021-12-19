using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour {

	public GameObject homePanel;
	public GameObject bookPanel;
	public GameObject quitPanel;
	public GameObject endPanel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			quitPanel.SetActive (true);
		}
	}

	public void GoBack(){
		GoToHomeMenu ();
		quitPanel.SetActive (false);
	}

	public void GoToHomeMenu()
	{
		homePanel.SetActive (true);
		bookPanel.SetActive (false);
		quitPanel.SetActive (false);
		endPanel.SetActive (false);
	}

	public void GoToBookMenu()
	{
		homePanel.SetActive (false);
		bookPanel.SetActive (true);
		quitPanel.SetActive (false);
		endPanel.SetActive (false);

	}

	public void GoToEndMenu()
	{
		homePanel.SetActive (false);
		bookPanel.SetActive (false);
		quitPanel.SetActive (false);
		endPanel.SetActive (true);
	}

	public void QuitApp()
	{
		Application.Quit ();
	}
		
}
