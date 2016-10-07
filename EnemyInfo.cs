using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyInfo : MonoBehaviour {
	public Renderer rend;
	private Transform myTransform;
    Enemy1 enemyName;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
        enemyName = GetComponent<Enemy1>();
	}
    void Update()
    {


    }
	void OnMouseEnter(){
		rend.material.color = new Color (255, 0, 0, 50);
	}
	void OnMouseOver(){
		rend.material.color = new Color (255, 0, 0,20)*Time.deltaTime;

	}
	void OnMouseExit(){
		rend.material.color = new Color (0, 0, 0, 0);
	}

}
