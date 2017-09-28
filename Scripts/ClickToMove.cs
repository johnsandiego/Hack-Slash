using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	NavMeshAgent navAgent;
	Animation animation;
	public float turnSpeed = 2f;
	public AnimationClip runAnimation;
	public AnimationClip idleAnimation;
	// Use this for initialization

	void Awake()
	{
		navAgent = GetComponent<NavMeshAgent>();
		animation = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update()
	{
		move ();
		animate ();

	}
	public void move()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if (Input.GetMouseButtonDown(0)) // 0 is Left-Click, 1 is Right-Click
		{
			if (Physics.Raycast(ray, out hit, 100))
			{
                
				
			}
		}
	}
	public void animate(){
		//if velocity > .5 play run animation
		//else play idle animation
		if (!Player.isAttacking) 
		{
			if (navAgent.velocity.magnitude > 0.5f) {
				animation.CrossFade (runAnimation.name);
			} else {
				animation.CrossFade (idleAnimation.name);
			}
		}
	}

}
