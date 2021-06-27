using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{


    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Volcano")
        {
            rigid.drag = 50;
            gameObject.layer = LayerMask.NameToLayer("Default");
        }

        if (col.gameObject.tag == "Volcano2")
        {
            rigid.drag = 50;
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tip")
        {
            rigid.drag = 1;
        }

        if (col.gameObject.tag == "Lava")
        {
            rigid.drag = 1;
        }

        if (col.gameObject.tag == "Destruction")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {

    }

   
}
