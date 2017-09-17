﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonInitializer : MonoBehaviour
{
	public LevelEnum levelEnum = LevelEnum.level_1_01;

	Level level;
	GameObject /*uiName, uiDifficulty,*/ uiLockImage;
	Button button;
	bool isStarted = false;

	// Use this for initialization
	void Start ()
	{
		Debug.Log (this.name + " = " + Time.time + " " + ApplicationController.ac.levels [levelEnum].name);
		//level = ApplicationController.ac.levels [levelEnum];
		//uiName = transform.Find ("Name").gameObject;
		uiLockImage = transform.Find ("LockImg").gameObject;
		//uiDifficulty = transform.Find ("Difficulty").gameObject;
		button = GetComponent<Button> ();
		InitButton ();
		// When object is Started, OnEnable() can be called
		isStarted = true;
	}

	void InitButton ()
	{
		level = ApplicationController.ac.levels [levelEnum];
		if (level.isLocked) {
			button.interactable = false;
			uiLockImage.GetComponent<Image> ().color = Color.red;
		} else {
			button.interactable = true;
			uiLockImage.GetComponent<Image> ().color = Color.green;
		}
	}

	void OnEnable ()
	{
		if (isStarted)
			Start ();
	}

}