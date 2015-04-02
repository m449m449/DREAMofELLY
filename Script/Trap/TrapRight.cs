using UnityEngine;
using System.Collections;

public class TrapRight : MonoBehaviour {
	public static int rightcol = 0;
	public float time = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(time < 0.1f){
			time += Time.deltaTime;
		}else{
			rightcol = 0;
		}
		
	
	}
	
	private void OnTriggerStay(Collider c){
		if(c.gameObject.tag == "Wall"){
			rightcol = 1;
			time = 0f;
		}
		
	}
}
