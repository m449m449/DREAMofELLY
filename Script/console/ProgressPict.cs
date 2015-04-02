using UnityEngine;
using System.Collections;
using System.IO;

public class ProgressPict : MonoBehaviour {
	float time = 0f;
	
	//GameObject StartPic;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Pop.escselect == 0){//Pause.
		//時間が経つと消える.
		time += Time.deltaTime;
		if(time > 1.0f){
			Object.Destroy(gameObject);
		}
		}
	}
}
