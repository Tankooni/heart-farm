using UnityEngine;
using System.Collections;

public class HeartBeatScript : MonoBehaviour {
	//values to initialize to
	const int STARTING_SIZE = 20;
	const int STARTING_BLOOD = 0;
	
	//other consts
	const int MAX_SIZE = 200;
	const double FILL_RATE = 1;
	
	//basic properties	
	double _size;
	double _blood;
	double _growthRate;
	public double Size 
	{
		get {return _size;}
		set {_size = value;}
	}
	public double Blood 
	{
		get {return _blood;}
		set {_blood = value;}
	}
	
	// Use this for initialization
	void Start () {
		_size = STARTING_SIZE;
		_blood = STARTING_BLOOD;
		_growthRate = .3;
	}
	
	// Update is called once per frame
	void Update () {
		//update size and blood amount
		_blood = (Time.deltaTime / 1000) * FILL_RATE;
		_size = (Time.deltaTime / 1000) * _growthRate;
		
		if(_size > MAX_SIZE)
			_size = MAX_SIZE;
		if(_blood > _size)
			_blood = _size;
	}
}
