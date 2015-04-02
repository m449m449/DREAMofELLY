using UnityEngine;
using System.Collections;

public class proT4pos : MonoBehaviour {

	
	public  GameObject protrap4;
	public static Vector3 T4pos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		T4pos = this.transform.position;
		
		if(GameObject.Find("proT4pos(Clone)")){
			Destroy (GameObject.Find("proT4pos(Clone)"));
		}
		
		
		if(TrapInstantiate.keyflag == 4){
			Instantiate (protrap4,new Vector3(T4pos.x,T4pos.y,T4pos.z),Quaternion.Euler(0, 0, 0));
		}else{
		}
		
	
	}
	
		private void OnTriggerStay(Collider c){

			if(GameObject.Find("proT4pos(Clone)")){
			Destroy (GameObject.Find("proT4pos(Clone)"));
		}
		}
		
}
