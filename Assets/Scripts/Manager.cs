using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{

    public static int playerOnePoints = 0;
    public static int playerTwoPoints = 0;
    public Text p1;
    public Text p2;
    public Text yellowWins = null;
    public Text redWins = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1.text = "P1: " + playerOnePoints;
        p2.text = "P2: " + playerTwoPoints;


        if(playerOnePoints == 3)
        {
            Time.timeScale = 0;
            yellowWins.text = "YELLOW WINS!";
        }

        if (playerTwoPoints == 3)
        {
            Time.timeScale = 0;
            redWins.text = "RED WINS!";
        }
    }
}
