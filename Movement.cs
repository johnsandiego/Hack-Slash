using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour {
	Animator anim;
	
	void Awake(){
		anim = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//turning
		//jumping
		//move
		move ();
	}
	void move()
	{
		anim.SetFloat ("Forward", Input.GetAxisRaw("Vertical"));
	}
}
