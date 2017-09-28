using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    public Player pl = new Player();

    public void OnStartGame(){
		Debug.Log("pressed Start");
		SceneManager.LoadScene("CharacterGeneration");
	}
	public void OnExitGame(){
		Application.Quit();

	}
    public void ContinueGame()
    {
        SceneManager.LoadScene("Main");
        pl.name = PlayerPrefs.GetString("name");
        pl.strength = PlayerPrefs.GetInt("strength");
        pl.defense = (PlayerPrefs.GetInt("defense"));
        pl.vitality= PlayerPrefs.GetInt("vitality");
        pl.speed = (PlayerPrefs.GetInt("speed"));
        pl.maxHealth = (PlayerPrefs.GetInt("vitality") * 50); ;
        pl.damage = (PlayerPrefs.GetInt("strength") * 2);
        
    }
}
