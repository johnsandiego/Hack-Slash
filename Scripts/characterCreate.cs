using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class characterCreate : MonoBehaviour {

    public new InputField name;
    public Text str, def, vit, spd, lvl, dps, hp, mp, gold,pointsLeft;
    Player pl = new Player();
    int Str, Def, Vit, Spd, pointsleft;
	// Use this for initialization
	void Awake () {
        Str = 10;
        Def = 10;
        Vit = 10;
        Spd = 10;
        pointsleft = 15;
        str.text = Str.ToString();
        def.text = Def.ToString();
        vit.text = Vit.ToString();
        spd.text = Spd.ToString();
        pointsLeft.text = pointsleft.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("name: " + name.text);
        str.text = Str.ToString();
        def.text = Def.ToString();
        vit.text = Vit.ToString();
        spd.text = Spd.ToString();
        pointsLeft.text = pointsleft.ToString();
    }
    public void SaveCharacterStat()
    {
        PlayerPrefs.SetString("name", name.text);
        PlayerPrefs.SetInt("strength", Str);
        PlayerPrefs.SetInt("defense", Def);
        PlayerPrefs.SetInt("vitality", Vit);
        PlayerPrefs.SetInt("speed", Spd);

    }
    public void addstrPoints()
    {
        if (pointsleft > 0)
        {
            Str += 1;
            pointsleft -= 1;
            str.text = Str.ToString();
        }
        else { }
    }
    public void adddefPoints()
    {
        if (pointsleft > 0)
        {
            Def += 1;
            pointsleft -= 1;
        }
    }
    public void addvitPoints()
    {
        if (pointsleft > 0)
        {
            Vit += 1;
            pointsleft -= 1;
        }
    }
    public void addspdPoints()
    {
        if (pointsleft > 0)
        {
            Spd += 1;
            pointsleft -= 1;
        }
    }
    public void substrPoints()
    {

        Str -= 1;
        pointsleft += 1;
    }
    public void subdefPoints()
    {
        Def -= 1;
        pointsleft += 1;
    }
    public void subvitPoints()
    {
        Vit -= 1;
        pointsleft += 1;
    }
    public void subspdPoints()
    {
        Spd -= 1;
        pointsleft += 1;
    }
    public void Create()
    {
        SaveCharacterStat();
        SceneManager.LoadScene(2);
    }
}
