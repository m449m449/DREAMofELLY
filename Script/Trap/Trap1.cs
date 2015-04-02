using UnityEngine;
using System.Collections;

public class Trap1 : MonoBehaviour {
	float vx,vz;
	
	// Use this for initialization
	void Start () {
		float ang;
		float y;
		ang = CameraControl.angle;
		y = CameraControl.upflag;
		if(y == 1f){
			y = 7.0f;
		}else{
			y = 3.0f;
		}
			//初速度.
			this.rigidbody.velocity = new Vector3(Mathf.Cos(ang)* 5.0f,y,Mathf.Sin(ang)* 5.0f);
		//this.rigidbody.velocity = TestCS.fvel;
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}
	
	
	
	private void OnTriggerEnter(Collider c){
		
		if(c.gameObject.tag == "Player" || c.gameObject.tag == "View"){
			
		}else{
			Destroy (this.gameObject);
		}
		
	}
	private void OnBecameInvisible(){
		Destroy (this.gameObject);
	
	}
}
