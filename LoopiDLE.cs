using UnityEngine;
using System.Collections;

public class LoopiDLE : MonoBehaviour {

    Animation anim;
    public AnimationClip idleAnimation;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.CrossFade(idleAnimation.name);
	}
}
