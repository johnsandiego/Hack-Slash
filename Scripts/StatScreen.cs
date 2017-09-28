using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StatScreen : MonoBehaviour {

    public Player pl = new Player();
    public new Text str, def, vit, spd, name, lvl, dps, hp, mp, gold, pointsLeft;
    public int pointsleft = 0;
    bool lvlcnt;
	// Use this for initialization
	void Start () {
        name.text = PlayerPrefs.GetString("name");
        str.text = PlayerPrefs.GetInt("strength").ToString();
        def.text = (PlayerPrefs.GetInt("defense")).ToString();
        vit.text = PlayerPrefs.GetInt("vitality").ToString() ;
        spd.text = (PlayerPrefs.GetInt("speed")).ToString();
        hp.text = (PlayerPrefs.GetInt("vitality") * 50).ToString(); ;
        dps.text = (PlayerPrefs.GetInt("strength")*2).ToString();
        lvlcnt = false;
    }
	
	// Update is called once per frame
	void Update () {
        name.text = pl.name;
        str.text = pl.strength.ToString();
        def.text = pl.defense.ToString();
        vit.text = pl.vitality.ToString();
        spd.text = pl.speed.ToString();
        lvl.text = pl.Level.ToString();
        dps.text = pl.damage.ToString();
        hp.text = pl.health.ToString();
        gold.text = pl.playerMoney.ToString();
        pointsLeft.text = pointsleft.ToString();
        lvlcnt = pl.lvlCount;
        addPoints();
    }
    void addPoints()
    {
        if (lvlcnt)
        {
            pointsleft = 5;
            pl.lvlCount = false;
        }

    }

    
    public void addstrPoints()
    {
        if (pointsleft > 0)
        {
            pl.strength += 1;
            pointsleft -= 1;
            pl.damage = pl.strength * 2;
        }
    }
    public void adddefPoints()
    {
        if (pointsleft > 0)
        {
            pl.defense += 1;
            pointsleft -= 1;
        }
    }
    public void addvitPoints()
    {
        if (pointsleft > 0)
        {
            pl.vitality += 1;
            pointsleft -= 1;
            pl.maxHealth = pl.vitality * 50;
            pl.health = pl.maxHealth;
        }
    }
    public void addspdPoints()
    {
        if (pointsleft > 0)
        {
            pl.speed += 1;
            pointsleft -= 1;
            
        }
    }
    public void substrPoints()
    {
        if(pointsleft > 0) { 
        pl.strength -= 1;
        pointsleft += 1;
        pl.damage = pl.strength * 2;
        }
    }
    public void subdefPoints()
    {
        if (pointsleft > 0)
        {
            pl.defense -= 1;
            pointsleft += 1;
        }
    }
    public void subvitPoints()
    {
        if (pointsleft > 0)
        {
            pl.vitality -= 1;
            pointsleft += 1;
            pl.maxHealth = pl.vitality * 50;
            pl.health = pl.maxHealth;
        }
        
    }
    public void subspdPoints()
    {
        if (pointsleft > 0)
        {
            pl.speed -= 1;
            pointsleft += 1;
            
        }
    }
}
