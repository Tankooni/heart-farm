using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
	public int fieldSize = 5;
	public GameObject plotObject;
	
	GameObject[,] plots;
	
	// Use this for initialization
	void Start()
	{
		plots = new GameObject[fieldSize,fieldSize];
		
		
		for(int i = 0; i < fieldSize; i++)
		{
			for(int j = 0; j < fieldSize; j++)
			{
				plots[i,j] = Instantiate(plotObject, new Vector3(i*plotObject.renderer.bounds.size.x,j*plotObject.renderer.bounds.size.y,0), Quaternion.identity) as GameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
