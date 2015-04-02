using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {
	GameObject  cover;
	GameObject  hole;
	Vector3 coverpos;
	float cooltime = 61f;
	Vector3 y;
	// Use this for initialization
	void Start () {
		hole = transform.parent.gameObject;
		cover = transform.FindChild("cover").gameObject;
		coverpos = cover.transform.position;
		y = coverpos;
	}
	
	// Update is called once per frame
	void Update () {
		if(cooltime > 1f){
			if(hole.gameObject.tag != "withHole"){
				cover.transform.position = coverpos;
				hole.gameObject.tag = "withHole";
			}
		}
		if(cooltime <= 45f){
			cooltime += Time.deltaTime;
		}
		
	}
	
	private void OnTriggerStay(Collider c){
		if(cooltime > 45f || cooltime <= 1f){
			if(c.gameObject.tag == "Enemy1" ||c.gameObject.tag == "Enemy2"){
				hole.gameObject.tag = "Hole";
				y.y = cover.transform.position.y - (1f * Time.deltaTime);
				this.cover.transform.position = y;
				if(cooltime  > 45f){
					cooltime = 0;
				}
			}
		}
	}
}
