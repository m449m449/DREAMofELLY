using UnityEngine;
using System.Collections;

public class Trap6 : MonoBehaviour {
	float reach = 0f;
	float cooltime = 0f;
	int turn = 0;
	public int triflag = 0;
	public int setrriger = 0;
	private GameObject punch;
	private GameObject punchbody;
	private GameObject range;
	Vector3 vector;
	Vector3 punchpos;
	Vector3 nowpos;
	AudioSource audioSource;
	public AudioClip bane;
	public AudioClip hit;
	//int layerMask = 1 << 8;
	
	// Use this for initialization
	void Start () {
		this.punch = this.transform.FindChild("Punch").gameObject;
		punchpos = this.punch.transform.position;
		this.range = this.transform.FindChild("T6Range").gameObject;
		
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		triflag = GetComponentInChildren<TrapTrigger>().triflag;
		if(triflag == 1){
			Trriger ();
		}
		if(GameState.statusflag != 0){
			Destroy(range);
		}
		
	}
	
	public void Trriger(){
		if(setrriger == 0){
			GetComponentInChildren<EnemyMotion>().animator.SetBool("punch",true);
			audioSource.PlayOneShot( bane );
			audioSource.PlayOneShot( hit );
			setrriger = 1;
		}
		if(cooltime == 0){
			if(reach < 2){
				punch.gameObject.tag = "Trap6";
				reach += Time.deltaTime * 10;
				this.punch.transform.position +=  this.punch.transform.forward * Time.deltaTime * 10;
			}else if(reach >= 2){
				GetComponentInChildren<EnemyMotion>().animator.SetBool("punch",false);
				this.punch.transform.position = punchpos;
				punch.gameObject.tag = "withPunch";
				turn = 1;
			}
		}
		if(turn == 1){
			cooltime += Time.deltaTime;
		}
		
		if(cooltime > 8){
			GetComponentInChildren<TrapTrigger>().triflag = 0;
			turn = 0;
			reach = 0;
			cooltime = 0;
			setrriger = 0;
		}
	}
}
