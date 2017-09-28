using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class teleportToBoss : MonoBehaviour {

    public GameObject teleportBoss;
    public Transform t;
    // Use this for initialization
    public Player pl;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        
    }
    void tele()
    {

        Debug.Log("passed Through");
        if (Vector3.Distance(teleportBoss.transform.position, t.transform.position) < pl.range)
        {
            SceneManager.LoadScene(4);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if(other.tag.Contains("Enemy")){

        }
        else{
            SceneManager.LoadScene(4);
        }
    }
}
