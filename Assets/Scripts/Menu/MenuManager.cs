﻿using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

public class MenuManager : MonoBehaviour
{
	public GameObject menu, phoneButton, vrButton, panel, pin, inputField, code, backButton;
	public enum SceneType { PHONE, VR };
	private InputField inpF;
	void Awake()
    {
		inpF = inputField.GetComponent<InputField>();
		inpF.characterLimit = 4;

        //phoneButton.GetComponent<Button>().onClick.AddListener(delegate { Play(SceneType.PHONE); });
        //vrButton.GetComponent<Button>().onClick.AddListener(delegate { Play(SceneType.VR); });
    }

	void Start() {
		panel.SetActive(false);
	}

	public void GOPiSandiMartr()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");
	}

    public void Player1Start() {
		vrButton.SetActive (false);
		phoneButton.SetActive (false);

		panel.SetActive(true);
		backButton.SetActive(true);
		inputField.SetActive(false);
		pin.SetActive(true);
		code.GetComponent<Text>().text = Networking.Instance.playAsPlayer1();
    }

	public void Player2Start() {
		PlayMusic.Instance.BASTAFERMALAMMUSICA();
		vrButton.SetActive(false);
		phoneButton.SetActive(false);

		panel.gameObject.SetActive(true);
		backButton.SetActive(true);
		inputField.SetActive(true);
		pin.SetActive(false);
    }

	public void backToPlayerSelection() {
		PlayMusic.Instance.BASTAFERMALAMMUSICA();
		panel.gameObject.SetActive(false);
		backButton.SetActive(false);
		inputField.SetActive(false);
		pin.SetActive(false);

		vrButton.SetActive(true);
		phoneButton.SetActive(true);
	}

	public void ConfirmPin() {
		string t = inpF.text;

		if (t.Length == 4) {
			try {
				Convert.ToInt32(t);
				Networking.Instance.playAsPlayer2(t);	
			} catch(Exception e) {
				inpF.text = "";
			}
		}
	}

	/*private void Play(SceneType plrType)
    {
        menu.SetActive(false);
		switch (plrType) {
			case SceneType.PHONE:
				// carica scena telefono
				break;
			case SceneType.VR:
				// carica scena vr
				break;
		}
		Debug.Log ("scena " + plrType + " caricata");

    }*/
}
