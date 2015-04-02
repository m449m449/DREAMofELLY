using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {

	public Animator animator;
	private int flag;
	private int hanabiflag;
	private float time;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
	}
}
