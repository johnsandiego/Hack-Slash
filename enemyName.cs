using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class enemyName : MonoBehaviour {

    NavMeshAgent navAgent;
    Enemy1 en;
    public Text txt;
    public Text healthNum;
    public Image healthIM;
    // Use this for initialization
    void Start () {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        try { 
        EnemyUI();
        if (en.health < 0)
        {
            healthNum.text = "0/" + en.maxHealth;
        }
        else {
         healthNum.text = en.health + "/" + en.maxHealth;
         }
        healthIM.fillAmount = Mathf.Lerp(healthIM.fillAmount,(float)en.health / en.maxHealth,.05f);
        }catch (System.NullReferenceException)
        {
            Debug.Log("No Target 2");
        }
    }
    void EnemyUI()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) // 0 is Left-Click, 1 is Right-Click
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                 
                Debug.Log(hit.collider);
                GameObject temp = hit.collider.gameObject;
                en = temp.GetComponent<Enemy1>();
                txt.text = en.name;
                healthNum.text = en.health.ToString()+"/"+en.maxHealth;
               
            }
        }
    }
}
