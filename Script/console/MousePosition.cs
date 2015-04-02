using UnityEngine;
using System.Collections;

public class MousePosition : MonoBehaviour {
	public Transform target;
	private int wallcol;
	private float time;
	private int p;
	private float screenPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameState.mouse == 0 && Pop.escselect == 0){
			if(time > 0.1){
				wallcol =0;
				time = 0;
			}
			time += Time.deltaTime;
			if(TrapInstantiate.keyflag == 2 || TrapInstantiate.keyflag == 3){
				p = -1;
			}else if(TrapInstantiate.keyflag == 5 || TrapInstantiate.keyflag == 6){
				p = 1;
			}
			screenPosition = Input.GetAxis("Mouse Y") * p;
			if(screenPosition < 0){
				target.localPosition = new Vector3(0,1,target.localPosition.z + screenPosition);
				if(target.localPosition.z < 4f){
					target.localPosition = new Vector3(0,1,4);
				}
			}else if(screenPosition > 0){
				if(wallcol == 0){
					target.localPosition = new Vector3(0,1,target.localPosition.z + screenPosition);
				}
			}
			target.position = new Vector3(target.position.x,1,target.position.z);
			target.transform.eulerAngles = new Vector3(0,target.transform.eulerAngles.y,0);
		}
	}
	
	private void OnTriggerStay(Collider c){
		if(c.gameObject.tag == "Wall" || c.gameObject.tag == "DummyWall"){
			//Debug.Log ("hit");
			wallcol = 1;
			time = 0;
		}
	}
}
