using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    private bool scoreStop = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreStop == false) {
            scoreText.text = (player.position.z + 50).ToString("0");
        }
    }

    public void scoreStoper()
    {
        scoreStop = true;
    }


}
