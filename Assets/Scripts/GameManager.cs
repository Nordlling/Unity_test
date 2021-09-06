using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;

    float restartDelay = 2f;

    public GameObject completeLevelUI;

    public GameObject failLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        Debug.Log("END");
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            failLevelUI.SetActive(true);
            Invoke("Restart", restartDelay);
        }

    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
