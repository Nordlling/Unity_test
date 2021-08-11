using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Mods : MonoBehaviour
{
    
    public static bool jumps;

    public bool getJumps(){
        return jumps;
    }
    private void Start()
    {

    }
    public void StartGame()
    {
        string nameButton = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(nameButton);
        
        if (nameButton == "Jumps")
        {
            jumps = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (nameButton == "NoJumps")
        {
            jumps = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

}
