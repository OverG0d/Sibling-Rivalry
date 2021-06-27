using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pillow : MonoBehaviour
{

    public GameObject volcano;
    public GameObject volcano2;

    public GameObject eruption;
    public GameObject eruption2;

    public GameObject tip;
    public GameObject tip2;

    Scene currentScene;


    // Start is called before the first frame update
    void Start()
    {

        currentScene = SceneManager.GetActiveScene();
        volcano = GameObject.FindGameObjectWithTag("Volcano");
        volcano2 = GameObject.FindGameObjectWithTag("Volcano2");

        eruption = GameObject.FindGameObjectWithTag("Eruption");
        eruption2 = GameObject.FindGameObjectWithTag("Eruption2");

        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene.name == "GameScene")
        {
            Physics2D.IgnoreCollision(volcano.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(volcano2.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            Physics2D.IgnoreCollision(eruption.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(eruption2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }


    }
}
