using UnityEngine;
using System.Collections;

public class pressSpace : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameState.statusflag == 1){
			Destroy(gameObject);
		}
	}
}
