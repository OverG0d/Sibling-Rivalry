using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int playerId;
    private Player player;
    Rigidbody2D rigid;
    public bool jumped;
    public float fireRate;
    private float nextFire;
    public GameObject spawnPoint_Left;
    public GameObject spawnPoint_Right;
    public float pillowSpeed;
    //Axis
    public float speed;
    float horizontalMovement;
    float verticalMovement;
    //Button Keys
    public bool jump;
    public bool throw_LeftSide;
    public bool throw_RightSide;
    public bool jump2;
    public bool jumped2;
    public bool pause;

    public GameObject pause_Menu;


    public GameObject pillow;

    public GameObject spawnOne;
    public GameObject spawnTwo;


    public GameObject p1;
    public GameObject p2;
    bool exit;
    bool space;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);

        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, -8.63f, 8.63f);
        playerPos.z = -1;
        transform.position = playerPos;

        GetInput();
        ProcessInput();
    }

    private void GetInput()
    {
        // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
        // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.
        horizontalMovement = player.GetAxis("Horizontal Movement");
        jump2 = player.GetButtonDown("Vertical Movement");
        throw_LeftSide = player.GetButtonDown("Throw Pillow Left");
        throw_RightSide = player.GetButtonDown("Throw Pillow Right");
        exit = player.GetButtonDown("Exit Game");
        space = player.GetButtonDown("Restart Level");
        jump = player.GetButtonDown("Jump");
        pause = player.GetButtonDown("Pause");
    }

    private void ProcessInput()
    {
        rigid.AddForce(transform.right * horizontalMovement * speed);
        
        if(jump && !jumped || jump2 && !jumped2)
        {
            rigid.AddForce(transform.up * 320);
            jumped = true;
            jumped2 = true;
        }

        if (throw_LeftSide && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject pillow_Clone = (GameObject)Instantiate(pillow, new Vector3(spawnPoint_Left.transform.position.x, spawnPoint_Left.transform.position.y, -9.52f), spawnPoint_Right.transform.rotation);
            pillow_Clone.GetComponent<Rigidbody2D>().AddTorque(100);
            pillow_Clone.GetComponent<Rigidbody2D>().velocity = -transform.right * pillowSpeed;
            Destroy(pillow_Clone, 15f);
        }

        if (throw_RightSide && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject pillow_Clone = (GameObject)Instantiate(pillow, new Vector3(spawnPoint_Right.transform.position.x,spawnPoint_Right.transform.position.y,-9.52f), spawnPoint_Right.transform.rotation);
            pillow_Clone.GetComponent<Rigidbody2D>().AddTorque(-100);
            pillow_Clone.GetComponent<Rigidbody2D>().velocity = transform.right * pillowSpeed;
            Destroy(pillow_Clone, 15f);
        }

        if(exit)
        {
            Scene scene = SceneManager.GetActiveScene();

            if(scene.name == "OG" || scene.name == "GameScene")
            {
                SceneManager.LoadScene(0);
            }
        }

        if (space)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Time.timeScale = 1;
            Manager.playerOnePoints = 0;
            Manager.playerTwoPoints = 0;
        }

        if(pause)
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
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            jumped = false;
            jumped2 = false;
        }

        if (col.gameObject.tag == "Volcano")
        {
            if (playerId == 0)
            {
                transform.position = spawnOne.transform.position;
                rigid.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

            if (playerId == 1)
            {
                transform.position = spawnTwo.transform.position;
                rigid.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }

        if (col.gameObject.tag == "Volcano2")
        {
            if (playerId == 0)
            {
                transform.position = spawnOne.transform.position;
                rigid.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

            if (playerId == 1)
            {
                transform.position = spawnTwo.transform.position;
                rigid.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            if (playerId == 0)
            {
                transform.position = spawnOne.transform.position;
                rigid.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

            if (playerId == 1)
            {
                transform.position = spawnTwo.transform.position;
                rigid.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }

        if (col.gameObject.tag == "Remote")
        {
            if (playerId == 0)
            {
                Manager.playerOnePoints++; 
                p1.transform.position = spawnOne.transform.position;
                p2.transform.position = spawnTwo.transform.position;
                p1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                p2.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

            if (playerId == 1)
            {
                Manager.playerTwoPoints++;
                p1.transform.position = spawnOne.transform.position;
                p2.transform.position = spawnTwo.transform.position;
                p1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                p2.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }
    }
}
