using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targeting : MonoBehaviour {
	public List <Transform> target;
	public Transform selectedTarget;

	private Transform myTransform;
	// Use this for initialization
	void Start () {
		target = new List<Transform> ();
		selectedTarget = null; // if script start no target
		myTransform = transform;
		AddAllEnemies ();
	}
	//add all enemies in the gameobject array
	public void AddAllEnemies(){
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Enemy");

		foreach (GameObject enemy in go)
			Addtarget (enemy.transform);

	}
	public void Addtarget(Transform enemy){
		target.Add (enemy);
	}

	private void sortTargetsByDistance(){
		//sorts the enemies by distance from the player
		target.Sort (delegate(Transform t1,Transform t2) {
			return(Vector3.Distance (t1.position, myTransform.position).CompareTo (Vector3.Distance (t2.position, myTransform.position)));
				});
	}
	//targets the enemy after sorting which enemy is closer
	private void TargetEnemy(){
		if (selectedTarget == null) {
			sortTargetsByDistance ();
			selectedTarget = target [0];
		} else {
			int index = target.IndexOf(selectedTarget);
			if(index < target.Count - 1)
			{
				index++;
			}
			else
			{
				index = 0;
			}
			DeselectTarget();
			selectedTarget = target[index];

		}
		SelectTarget();
	}
	private void SelectTarget(){
		selectedTarget.GetComponent<Renderer> ().material.color = Color.red;
		PlayerAttack pa = (PlayerAttack)GetComponent ("PlayerAttack");
		pa.target = selectedTarget.gameObject;
	}
	private void DeselectTarget(){
		selectedTarget.GetComponent<Renderer> ().material.color = Color.blue;
		selectedTarget = null;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			TargetEnemy ();
		}
	}
}
