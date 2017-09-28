using UnityEngine;
using System.Collections;



public class CameraSwitch : MonoBehaviour {
	
	public GameObject player;
	public GameObject FirstPersonCam;
	public GameObject ThirdPersonCam;
//	public Component CharContSwitch;
//	public Component FirstContSwitch;
	bool check;
	// Use this for initialization
	void Start () {
		ThirdPersonCam.gameObject.SetActive(true);
//		CharContSwitch = GetComponent<CharacterController> ();
//		FirstContSwitch = GetComponent<>();
		FirstPersonCam.gameObject.SetActive(false);
		check = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			if (check) {
				FirstPersonCam.gameObject.SetActive(false);
//				CharContSwitch.gameObject.SetActive (false);
//				FirstContSwitch.gameObject.SetActive (false);
				ThirdPersonCam.gameObject.SetActive (true);
			} else {
				FirstPersonCam.gameObject.SetActive(true);
//				CharContSwitch.gameObject.SetActive (true);
//				FirstContSwitch.gameObject.SetActive (true);
				ThirdPersonCam.gameObject.SetActive(false);
			}
			check = !check;
		}
	}
}
