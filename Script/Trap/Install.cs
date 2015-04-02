using UnityEngine;
using System.Collections;

public class Install : MonoBehaviour {
	float time;
	int colflag;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(colflag == 1){
			time += Time.deltaTime;
			if(time > 0.1f){
				//Debug.Log (TrapInstantiate.possible);//なぜか飛ばされる...(Debugの中身は関係ない)
				//TrapInstantiate.possible = 1;//なぜか飛ばされる...
				colflag = 0;//これは飛ばされい.
			}
		}else{
			TrapInstantiate.possible = 1;//上で飛ばされるからこっちで入れる.
		}
	}
	
	private void OnTriggerStay(Collider c){
		//Debug.Log (c.gameObject.tag);
		if(c.gameObject.tag == "Wall" || c.gameObject.tag == "withSpring" || c.gameObject.tag == "Trap2"
			 || c.gameObject.tag == "TaraiL" || c.gameObject.tag == "withPunch"
			|| c.gameObject.tag == "Trap7" || c.gameObject.tag == "DummyCeiling" || c.gameObject.tag == "Nucleus"
			|| c.gameObject.tag == "Goal"|| c.gameObject.tag == "DummyWall"){
			time = 0;
			colflag = 1;
			TrapInstantiate.possible = 0;
		}
	}
}
