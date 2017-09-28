using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	public Player player;
	NavMeshAgent navAgent;
	Animation animation;
	public AnimationClip runAnimation;
	public AnimationClip idleAnimation;
	// Use this for initialization
	public float chasingRange;

	void Awake()
	{
		navAgent = GetComponent<NavMeshAgent>();
		animation = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update()
	{
		FollowPlayer ();

	}
	void FollowPlayer(){
		if (IsInRange (chasingRange)) {
			
			if (navAgent.velocity.magnitude > 0.5f) {
				navAgent.SetDestination (player.transform.position);
				animation.CrossFade (runAnimation.name);
			}
		} else {
			navAgent.SetDestination (transform.position);
			animation.CrossFade (idleAnimation.name);
		}
		
	}
	bool IsInRange(float range)
	{
		if (Vector3.Distance (player.transform.position, transform.position) < range) {
			return true;
		} else {
			return false;
		}
		
	}

}
