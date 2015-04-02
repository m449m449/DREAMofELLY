using UnityEngine;
using System.Collections;

public class PlayerForwardCollider : MonoBehaviour {
	public int colflag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "Enemy1" || c.gameObject.tag == "Enemy2" || c.gameObject.tag == "Enemy3"){
				colflag = 1;
		}
		
	}
}
