using UnityEngine;
using System.Collections;

public class ButtonExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseExit(){
		if(Pop.escselect != 0){
			Pop.escselect = 1;
		}
		if(Pop.clearselect != 0){
			Pop.clearselect = 1;
		}
	}
}
