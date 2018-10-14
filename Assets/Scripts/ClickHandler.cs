using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour {

    int counter = 0;

	public void ButtonClicked()
    {
        Debug.Log("Click!");

        counter++;
        DisplayCounter();
    }

    public int GetCounter()
    {
        return counter;
    }

    public void ResetCounter()
    {
        counter = 0;
    }

    public void SetCounter(int i)
    {
        counter = i;
        DisplayCounter();
    }

    private void DisplayCounter()
    {
        Text textObject = gameObject.GetComponent<Text>();
        textObject.text = "" + counter;
    }
}
