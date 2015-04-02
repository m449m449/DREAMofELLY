using UnityEngine;
using System.Collections;

public class Skyrocket : MonoBehaviour {
	float vx,vz;
	GameObject player;
	Vector3 vec;
	float time;
	// Use this for initialization
	void Start () {
		this.player = GameObject.FindGameObjectWithTag("Player");
		vec = this.player.transform.forward * 5;
		vec.y = 3 * CameCon.pos.y;
		//初速度.
		//this.rigidbody.velocity = vec;
		//float ang;
		//float y;
		//ang = PlayerControl.angle;
		//y = CameraControl.pos.y * 3;
			//this.rigidbody.velocity = new Vector3(Mathf.Cos(ang)* 30.0f,y,Mathf.Sin(ang)* 30.0f);
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		//if(time > 0.3f){
			vec = this.transform.position + this.transform.forward * (50f * Time.deltaTime);
			vec.y -= 3 * Time.deltaTime;
			this.transform.position = vec;
		//}else{
		//	this.transform.position += this.transform.forward * (50f * Time.deltaTime);
		//}
	}
	
	
	
	private void OnTriggerEnter(Collider c){
		
		if(c.gameObject.tag == "Enemy1" ||c.gameObject.tag == "Enemy2"|| c.gameObject.tag == "Enemy3" || c.gameObject.tag == "Wall"){
			Debug.Log (c.gameObject.tag);
			Destroy (this.gameObject);
		}
		
	}
	private void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
}
