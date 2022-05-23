using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour {

	public Texture2D cursorTexture; // the 2d texture
	private CursorMode mode = CursorMode.ForceSoftware; // rendering
	private Vector2 hotSpot = Vector2.zero; // 

	//public GameObject mousePoint;
	private GameObject instantiatedMouse;

	void Update () {
		Cursor.SetCursor (cursorTexture, hotSpot, mode);
	}
} // class

