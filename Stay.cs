using UnityEngine;
using System.Collections;

public class Stay : MonoBehaviour
{
    float startX;
    // Use this for initialization
    void Start()
    {
        startX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(startX, this.transform.position.y), Time.deltaTime * 0.5f);
    }
}
