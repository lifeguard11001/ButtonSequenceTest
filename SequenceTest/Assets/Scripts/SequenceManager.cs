using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour {

	public List<Button> masterSequence;
	public Queue<Button> pressedButtons;
	public int[] sequenceSizes;
	int currentSequence = 0;
	int currentSequenceSize;
	[HideInInspector]
	public Console[] consoles;

	// Use this for initialization
	void Start () {

		consoles = FindObjectsOfType<Console>();
		CreateSequence();
		currentSequenceSize = sequenceSizes[currentSequence];
		pressedButtons = new Queue<Button>(currentSequenceSize);
	}
	
	// Update is called once per frame
	void Update () {
		Authenticate();
	}

	public void CreateSequence()
	{
		foreach(Console console in consoles)
		{
			foreach(Button button in console.buttons)
			{
				masterSequence.Add(button);
				button.ButtonPressed += AddPressedButtonToList;
			}

		}

		ShuffleSequence();
	}

	void ShuffleSequence()
	{
		for (int count = 0; count < masterSequence.Count; count++)
		{
			int randomValue = UnityEngine.Random.Range(count, masterSequence.Count);
			Button holder = masterSequence[randomValue];
			masterSequence[randomValue] = masterSequence[count];
			masterSequence[count] = holder;
		}
	}

	void AddPressedButtonToList(Button _button)
	{
		
		if (pressedButtons.Count + 1 > currentSequenceSize)
		{
			
			pressedButtons.Dequeue ();
			pressedButtons.Enqueue (_button); 
		}
		else
		{
			pressedButtons.Enqueue(_button);
		}

	}

	void Authenticate()
	{
		bool authenticated = false;

		if (pressedButtons.Count == currentSequenceSize)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Button[] listToCheck = pressedButtons.ToArray();
				int offset = 0;
				for (int count = 0; count < currentSequence; count++)
				{
					offset += sequenceSizes [count];

				}

				
				for (int count = offset; count < currentSequenceSize + offset; count++) {
					if (listToCheck [count - offset].buttonIndex == masterSequence [count].buttonIndex) {
						authenticated = true;
					}
					else
					{
						authenticated = false;
						break;
					}
				}

				if (authenticated)
				{
					pressedButtons.Clear();
					if (currentSequence < sequenceSizes.Length - 1) {
						currentSequence++;
						currentSequenceSize = sequenceSizes[currentSequence];
					}
					Debug.Log("Authenticated");
					

				}
				else
				{
					pressedButtons.Clear ();
					Debug.Log("Rejected");
				}
			}
		}
	}
}
