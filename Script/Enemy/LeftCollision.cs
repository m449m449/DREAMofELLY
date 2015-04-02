using UnityEngine;
using System.Collections;

public class LeftCollision : MonoBehaviour {
	public int colflag = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Trap6" || c.gameObject.tag == "Trap7"){
			colflag = 1;
		}
		
	}
}
