using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    public bool activated;
    public bool grounded;
    public bool mouseOver;
    public float forceY;
    public float forceX;

    public Transform topLeft;
    public Transform bottomRight;

    // Use this for initialization
    void Start()
    {

        activated = false;
        mouseOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mouseOver)
        {
            if (!activated)
            {
                activated = true;
                StartCoroutine(AI());
            }
        }


    }

    void OnMouseEnter()
    {
        mouseOver = true;
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }

    void GroundCheck()
    {
        int layerValue = 8;
        // This is used to illustrate which Layer we want to use.

        int layer = 1 << layerValue;
        grounded = Physics2D.OverlapArea(topLeft.position, bottomRight.position, layer);// ,layer.value);
        Debug.Log(grounded);
    }

    public IEnumerator AI()
    {
        yield return new WaitForSeconds(1.5f);
        do
        {
            GroundCheck();
            if (grounded)
            {
                Debug.Log("jump");
                GetComponent<JelloPressureBody>().AddForce(Vector2.up * (forceY + Random.Range(-100f, 100f)));
                GetComponent<JelloPressureBody>().AddForce(Vector2.right * (forceX + Random.Range(-25f, 50f)));


            }

            yield return new WaitForSeconds(0.5f);
        } while (true);

    }
}
