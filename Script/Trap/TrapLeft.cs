using UnityEngine;
using System.Collections;

public class TrapLeft : MonoBehaviour {
	public static int leftcol = 0;
	public float time = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(time < 0.1f){
			time += Time.deltaTime;
		}else{
			leftcol = 0;
		}
		
	
	}
	
	private void OnTriggerStay(Collider c){
		if(c.gameObject.tag == "Wall"){
			leftcol = 1;
			time = 0f;
		}
		
	}
}
