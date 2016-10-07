using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class teleportHome : MonoBehaviour {

    public GameObject teleporter;
    public Enemy1 evilOrc;
    public Player Pl;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        NPC();
	}

    void NPC()
    {
        try { 
        if (evilOrc.health < 0)
        {

            teleporter.SetActive(true);
          
           
            
        }}
        catch (System.NullReferenceException)
        {
            Debug.Log("No object selected");
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Enemy"))
        {

        }
        else {
            SceneManager.LoadScene(5);
        }
    }
}
