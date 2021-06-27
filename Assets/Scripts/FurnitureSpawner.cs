using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSpawner : MonoBehaviour
{

    public GameObject beanBag;
    public GameObject bookShelf;
    public GameObject emptyShelf;
    public GameObject Stool;

    public GameObject spawnOne;
    public GameObject spawnTwo;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FurnitureSpawn", 18f, 18f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FurnitureSpawn()
    {
        int randNum = Random.Range(0, 4);
        if(randNum == 0)
        {
            Instantiate(Stool, spawnOne.transform.position, spawnOne.transform.rotation);
            Instantiate(Stool, spawnTwo.transform.position, spawnTwo.transform.rotation);
        }
        if (randNum == 1)
        {
            Instantiate(bookShelf, spawnOne.transform.position, spawnOne.transform.rotation);
            Instantiate(bookShelf, spawnTwo.transform.position, spawnTwo.transform.rotation);
        }
        if (randNum == 2)
        {
            Instantiate(emptyShelf, spawnOne.transform.position, spawnOne.transform.rotation);
            Instantiate(emptyShelf, spawnTwo.transform.position, spawnTwo.transform.rotation);
        }
        if (randNum == 3)
        {
            Instantiate(beanBag, spawnOne.transform.position, spawnOne.transform.rotation);
            Instantiate(beanBag, spawnTwo.transform.position, spawnTwo.transform.rotation);
        }
    }
}
