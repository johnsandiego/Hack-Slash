using UnityEngine;
using System.Collections;

public class SpellAttack : MonoBehaviour {

    GameObject fireworksPrefab;
    public GameObject fireworks;
    public GameObject startPos;
    //public Player pl;
   // void OnParticleCollision(GameObject other)
   // {
    //    Rigidbody body = other.GetComponent<Rigidbody>();
    //    Enemy1 en = other.GetComponent<Enemy1>();
    //    if (body) { 
    //        en.GetHit(pl.damage);
    //        
    //    }
   // }
    void Update()
    {
        Debug.Log("WOOWOWOW");
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            LaunchSpell();
        }
    }
    void LaunchSpell()
    {
        Debug.Log("spell");
        fireworksPrefab = Instantiate(fireworks, startPos.transform.position, Quaternion.identity) as GameObject;


    }
}
