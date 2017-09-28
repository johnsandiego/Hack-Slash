
using System.Collections;
using UnityEngine;

public class Enemy1: Creature {

	Player player;
	public static Enemy1 enemy;
	bool block;
	Animation animation;
	NavMeshAgent navAgent;
	public float chasingRange;
	public AnimationClip runAnimation;
	public AnimationClip idleAnimation;
	public AnimationClip AttackAnimation;
	public AnimationClip deathAnimation;
    public AudioSource enemyMoan;
    public AudioSource enemyDeath;
    void Awake(){
		player = Player.player;
		navAgent = GetComponent<NavMeshAgent>();
		animation = GetComponent<Animation> ();
		health = maxHealth;
		enemy = this;
        navAgent.speed = enemy.speed;
	}
	void Start(){
		player = Player.player;
		navAgent = GetComponent<NavMeshAgent>();
		animation = GetComponent<Animation> ();
	}
	void Update(){

		FollowPlayer ();
		Attack ();
		Dead ();

	}
	//kamehameha
	public void GetHit(int playerDamage){
        health = health - (playerDamage - (defense / 2));

    }
	void OnMouseOver()
	{
		Player.opponent = transform;
	}

	void FollowPlayer(){
        if (IsInRange(chasingRange)) {

            navAgent.SetDestination(player.transform.position);
            
            animation.CrossFade(runAnimation.name);
            if(Vector3.Distance(player.transform.position, transform.position) < range)
           {
                animation.CrossFade(AttackAnimation.name);
                
                Attack();
                enemyMoan.PlayDelayed(1);
            }
        }
        else {
                navAgent.SetDestination(transform.position);
                animation.PlayQueued(idleAnimation.name);

            }
        

	}
	 protected override void Attack(){
		if (IsInRange (range)) {


			if (Vector3.Distance (player.transform.position, transform.position) < range && !block) {
				Debug.Log("Is in range");
                player.GetHit(damage);
				
				block = true;
				Invoke ("UnBlock", attackSpeed);
			}
		}
	}
	void UnBlock()
	{
		block = false;
	}
	// return if enemy is within range
	bool IsInRange(float range)
	{
		if (Vector3.Distance (player.transform.position, transform.position) < range) {
			return true;
		} else
			return false;

	}
	void Dead(){
		if (health < 0) {
			animation.CrossFade (deathAnimation.name);
			Debug.Log ("Enemy IS DEAD!");
            enemyDeath.Play(1);
			Destroy (this.gameObject,1.5f);

		}
	}
}
