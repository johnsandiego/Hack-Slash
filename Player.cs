using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Creature {

	public static bool isAttacking;
    //raycasted enemy gameobject
	Enemy1 enemHealth;
    public GameObject inventory;
    public GameObject craftSystem;
    public GameObject characterSystem;
    public GameObject armorStore;
    public GameObject potionStore;
    public GameObject statistic;
    public GameObject NPC;
    public Quest Q;
    //Audio
    [SerializeField]
    public AudioClip attacksource;
    private AudioSource m_AudioSource;
    //StartOptions stOption = new StartOptions();


    public static Transform opponent;
	public static Player player;

	public AnimationClip attackAnimation;
	public AnimationClip death;

    new Animation animation;
    public int playerMoney = 100;

	public float attackImpact;
	NavMeshAgent navAgent;
	public float turnSpeed = 2f;

	public AnimationClip runAnimation;
	public AnimationClip idleAnimation;

	public GameObject point;
	GameObject pointPrefab;
    float expMaxValue = 1000f;
    public float expCurrentValue=0;
    public Text playerLvl;
    public Image PlayerExp;
    public new AudioSource audio;

    public GameObject fireworks;
    GameObject fireworksPrefab;
    public bool lvlCount = false;
    Player pl;
    //StatScreen statScreen = new StatScreen();
    void Awake(){
		enemHealth = Enemy1.enemy;
		navAgent = GetComponent<NavMeshAgent>();
		animation = GetComponent<Animation> ();
		player = this;
		health = maxHealth;
		initAnimations ();
		isAttacking = false;
         audio = GetComponent<AudioSource>();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            PlayerInventory playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
            if (playerInv.inventory != null)
                inventory = playerInv.inventory;
            if (playerInv.craftSystem != null)
                craftSystem = playerInv.craftSystem;
            if (playerInv.characterSystem != null)
                characterSystem = playerInv.characterSystem;
            if (playerInv.armorStore != null)
                armorStore = playerInv.armorStore;
            if (playerInv.potionStore != null)
                potionStore = playerInv.potionStore;
        }
        player.name = PlayerPrefs.GetString("name");
        player.strength = PlayerPrefs.GetInt("strength");
        player.defense = PlayerPrefs.GetInt("defense");
        player.vitality = PlayerPrefs.GetInt("vitality");
        player.speed = PlayerPrefs.GetInt("speed");
        player.maxHealth = player.vitality * 50;
        player.damage = player.strength * 2;
        player.health = player.maxHealth;
    }

	void initAnimations(){
		
		animation = GetComponent<Animation>();
		AnimationEvent attackEvent = new AnimationEvent ();
		attackEvent.time = attackImpact;
		attackEvent.functionName = "impact";
		attackAnimation.AddEvent (attackEvent);
	}
	void impact(){
		Debug.Log ("Attack");
	}
	public void GetHit(int playerDamage){
        health = health - (playerDamage - (defense / 2));

    }
	void Update(){
        try {
            move();
            animate();
            Target();
            playerLevel();
        }
        catch(System.NullReferenceException)
        {
            Debug.Log("Null Target");
        }
		Death();

        
    }

	protected override void Attack(){
		if(Input.GetKeyUp(KeyCode.Space))
		{
			Debug.Log ("Attack");

			if (opponent != null && Vector3.Distance (opponent.position, transform.position) > range) {
				
				animation.Play (attackAnimation.name);
                audio.Play();
				//	animation.CrossFade(attackAnimation.name);
				//		opponent.GetComponent<Enemy>().GetHit(damage);
				isAttacking = true;

			} 
			}
		if (animation.IsPlaying (attackAnimation.name)) {
			isAttacking = false;
		}

		}

    void Death()
    {
        //SaveGame();
        string scene = "Main";
        string scene2 = "Map2";
        string scene3 = "BossMap";
        string scene4 = "QuestComplete";
        if (player.health <= 0) { 
        animation.Play(death.name);
            if (scene.Contains(SceneManager.GetActiveScene().name))
            {
                SceneManager.LoadScene(2);
            }else if (scene2.Contains(SceneManager.GetActiveScene().name))
            {
                SceneManager.LoadScene(3);
            }
            else if (scene3.Contains(SceneManager.GetActiveScene().name))
            {
                SceneManager.LoadScene(4);
            }

        }
    }
    void SaveGame()
    {
        PlayerPrefs.SetString("name", pl.name);
        PlayerPrefs.SetInt("strength", pl.strength);
        PlayerPrefs.SetInt("defense", pl.defense);
        PlayerPrefs.SetInt("vitality", pl.vitality);
        PlayerPrefs.SetInt("speed", pl.speed);
        Debug.Log("Game Saved!");
        Debug.Log("Player damage" + pl.damage);
        Debug.Log("Player str" + pl.strength);

    }
    private void attackSound()
    {
        m_AudioSource.clip = attacksource;
        m_AudioSource.Play();
    }
    void Target()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) // 0 is Left-Click, 1 is Right-Click
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject temp = hit.collider.gameObject;
                Enemy1 en = temp.GetComponent<Enemy1>();
                enemHealth = en;
                
                //level up function
                
            }
        }
    }
    //level up function
    void playerLevel() {
        if (enemHealth.health <= 0)
        {
            Debug.Log("enemy died you will earn exp");
            if (expCurrentValue < expMaxValue)
            {
                
                Debug.Log("exp earned: " + enemHealth.experiencePoints);
                expCurrentValue += enemHealth.experiencePoints;
                enemHealth = null;

            }
            else if (expCurrentValue >= expMaxValue)
            {
                Debug.Log("Level up" + Level);
                float exptemp = expCurrentValue / expMaxValue;
                float remainder = expCurrentValue % expMaxValue;
                fireworksPrefab = Instantiate(fireworks, player.transform.position, Quaternion.identity) as GameObject;
                Level += (int)exptemp;
                lvlCount = true;
                expCurrentValue = remainder; 
                enemHealth = null;
                //Destroy(fireworksPrefab.gameObject, 6f);
            }
        }
        playerLvl.text = Level.ToString();
        PlayerExp.fillAmount = expCurrentValue / expMaxValue;
    }
	public void move()
	{
        if (!lockMovement())
        {
            GameObject[] checkTag = GameObject.FindGameObjectsWithTag("Point");

            //		anim.SetFloat ("Forward", Input.GetAxisRaw("Vertical"));
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0)) // 0 is Left-Click, 1 is Right-Click
            {
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (checkTag.Length > 0)
                    {
                        Destroy(pointPrefab.gameObject);

                    }
                    else {
                        pointPrefab = Instantiate(point, hit.point, point.transform.rotation) as GameObject;
                    }
                    Destroy(pointPrefab.gameObject, 2f);
                    navAgent.angularSpeed = turnSpeed;
                    navAgent.SetDestination(hit.point);
                }
            }
        }
	}
	public void animate(){
		//if velocity > .5 play run animation
		//else play idle animation
		if (!Player.isAttacking) 
		{
			if (navAgent.velocity.magnitude > 0.5f) {
				animation.Play (runAnimation.name);
			} else if (Input.GetKeyUp (KeyCode.Space)) {
                audio.Play(2);
                animation[attackAnimation.name].speed = 3f;
                animation.Play (attackAnimation.name);
                
				enemHealth.GetHit (damage);
                

			} else {
				animation.PlayQueued (idleAnimation.name);
			}

			//else
			//	animation.CrossFade (idleAnimation.name);
			}
		}
    bool lockMovement()
    {
        if (inventory != null && inventory.activeSelf)
            return true;
        else if (characterSystem != null && characterSystem.activeSelf)
            return true;
        else if (craftSystem != null && craftSystem.activeSelf)
            return true;
        else if (statistic != null && statistic.activeSelf)
            return true;
        else
            return false;
    }
}


