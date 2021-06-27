using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Selector : MonoBehaviour
{
    public int playerId;
    private Player player;
    float horizontalMovement;
    public Image selector;
    public bool left;
    public bool right;
    public bool select;
    public bool exit;
    public bool pause;
    float x;
    public GameObject pause_Menu;
    // Start is called before the first frame update
    void Start()
    {
        
        player = ReInput.players.GetPlayer(playerId);
        LevelSelect.index = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        GetInput();
        ProcessInput();
    }

    private void GetInput()
    {

            horizontalMovement = player.GetAxis("Horizontal Movement");
            left = player.GetButtonDown("LevelSelect_Left");
            right = player.GetButtonDown("LevelSelect_Right");
            select = player.GetButtonDown("Select");
            exit = player.GetButtonDown("Exit Game");
            pause = player.GetButtonDown("Pause");
    }

    private void ProcessInput()
    {
        if (right && LevelSelect.index == 0)
        {
            LevelSelect.index++;
            x = selector.GetComponent<RectTransform>().anchoredPosition.x;
            x += 560;
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(x, 0, 0);

        }


        if (left && LevelSelect.index == 1)
        {
            LevelSelect.index--;
            x = selector.GetComponent<RectTransform>().anchoredPosition.x;
            x -= 560;
            selector.GetComponent<RectTransform>().anchoredPosition = new Vector3(x, 0, 0);
        }

        if (LevelSelect.index == 0 && select)
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }

        if (LevelSelect.index == 1 && select)
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
        }


        if (pause)
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                pause_Menu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                pause_Menu.SetActive(true);
            }
        }

        if (exit)
        {
            Application.Quit();
        }
    }
}
