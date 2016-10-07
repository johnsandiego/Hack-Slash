using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float heigth = 10;

	public float radius = 10;
	public float angle = 0;
	public float rotationalSpeed = 150;
    public float cameraZ;
    public float cameraY;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float cameraX = target.position.x + (radius*Mathf.Cos(angle));
		cameraY = target.position.y + heigth;
		cameraZ = target.position.z + (radius*Mathf.Sin(angle));

		transform.position = new Vector3(cameraX, cameraY, cameraZ);

		if (Input.GetKey (KeyCode.Q)) {
			angle = angle - rotationalSpeed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.E)) {
			angle = angle + rotationalSpeed * Time.deltaTime;
		}
		transform.LookAt (target.position);

	}
}
