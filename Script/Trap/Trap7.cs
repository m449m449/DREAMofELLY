using UnityEngine;
using System.Collections;

public class Trap7 : MonoBehaviour {
	GameObject plane;
	GameObject nucleus;
	float cooltime = 5f;
	float rz = -90;
	int turnflag;
	
	// Use this for initialization
	void Start () {
		this.plane = transform.FindChild("Plane").gameObject;
		this.nucleus = transform.FindChild("Nucleus").gameObject;
		this.transform.rotation = Quaternion.Euler(0f,transform.eulerAngles.y,rz);	
		this.plane.transform.rotation = Quaternion.Euler(0f,this.transform.eulerAngles.y,0f);
		this.nucleus.transform.rotation = Quaternion.Euler(0f,this.transform.eulerAngles.y,0f);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(cooltime >= 3f){
			if(turnflag == 0){
				rz += Time.deltaTime * 200;
				this.transform.rotation = Quaternion.Euler(0f,transform.eulerAngles.y,rz);
				this.plane.transform.rotation = Quaternion.Euler(0f,this.transform.eulerAngles.y,0f);
				this.nucleus.transform.rotation = Quaternion.Euler(0f,this.transform.eulerAngles.y,0f);
				if(rz >= 90){
					turnflag = 1;
					cooltime = 0;
				}
			}else if(turnflag == 1){
				rz -= Time.deltaTime * 200;
				this.transform.rotation = Quaternion.Euler(0f,transform.eulerAngles.y,rz);
				this.plane.transform.rotation = Quaternion.Euler(0f,this.transform.eulerAngles.y,0f);
				this.nucleus.transform.rotation = Quaternion.Euler(0f,this.transform.eulerAngles.y,0f);
				if(rz <= -90){
					turnflag = 0;
					cooltime = 0;
				}
			}	
		}else{
			cooltime += Time.deltaTime;
		}
	}
}
