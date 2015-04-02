using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Pop.escselect == 0){
			camera.depth = 1;
		}else{
			camera.depth = -2;
		}
	}
}
