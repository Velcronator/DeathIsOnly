using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{

	public Texture2D cursorTexture; // 2d texture
	private CursorMode mode = CursorMode.ForceSoftware; // force the render
	private Vector2 hotSpot = Vector2.zero;

	public GameObject mousePoint; // prefab
	private GameObject instantiatedMouse; // new dude

	void Update()
	{
		//Cursor.SetCursor (cursorTexture, hotSpot, mode);

		if (Input.GetMouseButtonUp(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			RaycastHit raycastHit; // the hit

			if (Physics.Raycast(ray, out raycastHit))
			{
				if (raycastHit.collider is TerrainCollider) 
				{
					Vector3 temp = raycastHit.point;
					temp.y = 0.25f; // so it's above the ground

					if (instantiatedMouse == null) // if we don't have a pointer instantiate one
					{
						instantiatedMouse = Instantiate(mousePoint);
						instantiatedMouse.transform.position = temp;
					}
					else // Destroy the old one then create a new one
					{
						Destroy(instantiatedMouse);
						instantiatedMouse = Instantiate(mousePoint);
						instantiatedMouse.transform.position = temp;
					}
				}
			}
		}

	}


} // class
