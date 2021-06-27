using UnityEngine;
using System.Collections;

public class TextureScroller : MonoBehaviour
{
    public float speed = 0.5f;
    public float start = 0;

    Vector2 offset = new Vector2(0, 0);

    void Update()
    {
        offset.x = start + Time.time * speed;

        gameObject.GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}


