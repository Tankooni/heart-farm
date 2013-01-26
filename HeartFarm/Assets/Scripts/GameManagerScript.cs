using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
	public int fieldSize = 5;
	public GameObject plotObject;
	public GameObject fieldObject;
	public GameObject heartBeetObject;
	
	GameObject[,] plots;
	
	// Use this for initialization
	void Start()
	{
		plots = new GameObject[fieldSize,fieldSize];
		
		
		for(int i = 0; i < fieldSize; i++)
		{
			for(int j = 0; j < fieldSize; j++)
			{
				plots[i,j] = Instantiate(plotObject, new Vector3(i*plotObject.renderer.bounds.size.x * 1.2f, j * plotObject.renderer.bounds.size.y * 1.2f, 0), Quaternion.identity) as GameObject;
			}
		}
		fieldObject = Instantiate(fieldObject, Vector3.zero, Quaternion.identity) as GameObject;
		
		float temp = fieldObject.transform.localScale.x * 1.2f * fieldSize;
		fieldObject.transform.localScale = new Vector3(temp, temp, 0);
		
		//make a beet
		Instantiate(heartBeetObject, new Vector3(0, 0, -1), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update()
	{
		//process mouse events
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if(Physics.Raycast(mouseRay, out hit))
		{
			GameObject beet = hit.collider.gameObject;
			//if(beet.name == "
			//show the tooltip
			beet.SendMessage("DrawGUI");
			//perform an action if this was a click event
			if(Input.GetMouseButtonDown(0))
			{
				
			}
		}
	}

}
