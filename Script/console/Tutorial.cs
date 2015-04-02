using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	public int click;
	void OnMouseUp(){
		Pop.escselect = click;
	}
}
