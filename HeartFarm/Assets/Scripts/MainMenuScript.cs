using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{
	public int fieldSize = 5;
	public GameObject plotObject;
	public GameObject fieldObject;
	
	GameObject[,] plots;
	
	// Use this for initialization
	void Start()
	{
		plots = new GameObject[fieldSize,fieldSize];
		
		
		for(int i = 0; i < fieldSize; i++)
		{
			for(int j = 0; j < fieldSize; j++)
			{
				plots[i,j] = Instantiate(plotObject, new Vector3(i*plotObject.renderer.bounds.size.x * 1.2f - fieldSize * plotObject.renderer.bounds.size.x/2, j * plotObject.renderer.bounds.size.y * 1.2f - fieldSize * plotObject.renderer.bounds.size.y/2, 0), Quaternion.identity) as GameObject;
			}
		}
		fieldObject = Instantiate(fieldObject, Vector3.zero, Quaternion.identity) as GameObject;
		
		float temp = fieldObject.transform.localScale.x * 1.5f * fieldSize;
		fieldObject.transform.localScale = new Vector3(temp, temp, 0);
	}
	
	void OnGUI()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
