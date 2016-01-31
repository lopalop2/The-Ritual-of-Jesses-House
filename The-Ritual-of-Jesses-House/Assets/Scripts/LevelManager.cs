﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
	public Transform mainMenu, optionMenu, creditsMenu;
	public EventSystem menuSystem;
	public GameObject firstOption;
	public GameObject returnToMenu;

	public Slider volumeSlider;
	public AudioSource volumeEffect;

	public Slider soundSlider;
	public AudioSource soundEffects;


	public void StartScene () 
	{
		SceneManager.LoadScene ("");
		menuSystem.SetSelectedGameObject (gameObject.GetComponent<GameObject> ().GetComponentInChildren<Button> ().gameObject);
		foreach (GameObject temp in GetComponents<GameObject>()) 
		{
			if (temp.name == "MainMenu") 
			{
				firstOption = temp;
				break;
			}
		}
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void OptionsMenu(bool clicked)
	{
		if (clicked == true) {
			optionMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
			menuSystem.SetSelectedGameObject (returnToMenu);
		} else {
			mainMenu.gameObject.SetActive (true);
			optionMenu.gameObject.SetActive (clicked);
			menuSystem.SetSelectedGameObject (firstOption);
			volumeEffect.Stop ();
		}
	}

	public void CreditsMenu(bool clicked)
	{
		if (clicked == true) {
			creditsMenu.gameObject.SetActive (clicked);
			mainMenu.gameObject.SetActive (false);
			menuSystem.SetSelectedGameObject (returnToMenu);
		} else {
			mainMenu.gameObject.SetActive (true);
			creditsMenu.gameObject.SetActive (clicked);
			menuSystem.SetSelectedGameObject (firstOption);
		}
	}

	public void volumeManager()
	{
		if (!volumeEffect.isPlaying) 
		{
			volumeEffect.Play ();
		}
	}

	public void SoundManager()
	{
		if (!soundEffects.isPlaying) 
		{
			soundEffects.Play ();
			volumeEffect.Stop ();
		}
	}


	void Update () 
	{
		volumeEffect.volume = volumeSlider.value;
		soundEffects.volume = soundSlider.value;

	}
}
