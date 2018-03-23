using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button : MonoBehaviour {

	public enum Color {Red, Green, Blue, Yellow, Orange, Purple };
	public Color buttonColor;
	[HideInInspector]
	public bool wasPressed = false;
	public int buttonIndex;
	public event Action<Button> ButtonPressed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		OnPressed();
	}

	public void OnPressed()
	{
		if(buttonColor == Color.Red)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				wasPressed = true;
				Debug.Log("You pressed the " + buttonColor.ToString() + "\nIndex: " + buttonIndex);
				if(ButtonPressed != null)
				{
					ButtonPressed(this);
				}
			}
		}

		if (buttonColor == Color.Blue)
		{
			if (Input.GetKeyDown(KeyCode.B))
			{
				wasPressed = true;
				Debug.Log("You pressed the " + buttonColor.ToString() + "\nIndex: " + buttonIndex);
				if (ButtonPressed != null)
				{
					ButtonPressed(this);
				}
			}
		}

		if (buttonColor == Color.Green)
		{
			if (Input.GetKeyDown(KeyCode.G))
			{
				wasPressed = true;
				Debug.Log("You pressed the " + buttonColor.ToString() + "\nIndex: " + buttonIndex);
				if (ButtonPressed != null)
				{
					ButtonPressed(this);
				}
			}
		}

		if (buttonColor == Color.Orange)
		{
			if (Input.GetKeyDown(KeyCode.O))
			{
				wasPressed = true;
				Debug.Log("You pressed the " + buttonColor.ToString() + "\nIndex: " + buttonIndex);
				if (ButtonPressed != null)
				{
					ButtonPressed(this);
				}
			}
		}

		if (buttonColor == Color.Yellow)
		{
			if (Input.GetKeyDown(KeyCode.Y))
			{
				wasPressed = true;
				Debug.Log("You pressed the " + buttonColor.ToString() + "\nIndex: " + buttonIndex);
				if (ButtonPressed != null)
				{
					ButtonPressed(this);
				}
			}
		}

		if (buttonColor == Color.Purple)
		{
			if (Input.GetKeyDown(KeyCode.P))
			{
				wasPressed = true;
				Debug.Log("You pressed the " + buttonColor.ToString() + "\nIndex: " + buttonIndex);
				if (ButtonPressed != null)
				{
					ButtonPressed(this);
				}
			}
		}

		wasPressed = false;
	}
}
