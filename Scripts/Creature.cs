using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour {

    public NavMeshAgent enemyNav;

    public new string name;

    public int maxHealth;

	public int health;

	public int strength;

    public int damage;

    public int vitality;

    public int defense;

    public int speed;

    public int experiencePoints;

    public int Level;

	public float range;

	public float attackSpeed = 2f;

	public void GetHit (int playerDamage)
	{
		health = health - (playerDamage - (defense/2));
	}
	protected abstract void Attack();
	
}
