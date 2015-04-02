using UnityEngine;
using System.Collections;

public class RangeDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameState.statusflag != 0){
			Destroy(gameObject);
		}
	}
}
