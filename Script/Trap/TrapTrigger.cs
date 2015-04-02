using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {
	
	public int triflag = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		
	}
	
	
	private void OnTriggerEnter(Collider c){
		//Debug.Log (c.gameObject.tag);
		if(c.gameObject.tag == "Enemy1" ||c.gameObject.tag == "Enemy2"|| c.gameObject.tag == "Enemy3"){
			triflag = 1;
		}
	}
}
