using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Quest : MonoBehaviour {


	/// <summary>
	/// Must include a way to lock movement while accepting quest
	/// away to win the quest. so include an image that shows
	/// the player won and get rid of the quest tab.
	/// </summary>
	GameObject NPCimage;
	public GameObject Image;
	public GameObject questTab;
    public bool npcOpen = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void acceptQ(){
		Debug.Log ("accepted");
		questTab.SetActive (true);
		Image.SetActive (false);
	}
	public void ignoreQ(){
		Image.SetActive (false);
	}

}
	