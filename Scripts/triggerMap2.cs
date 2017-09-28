using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class triggerMap2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter()
    {
        SceneManager.LoadScene(3);
    }
}
