using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    public bool activated;
    public bool grounded;
    public bool mouseOver;
    public float forceY;
    public float forceX;

    public float yVelocity;
    public float prevY;
    public float currentY;
    public float yVelocityCutOff;

    public bool GOINGDOWN;

    public Transform topLeft;
    public Transform bottomRight;


    private IEnumerator ai;
    // Use this for initialization
    void Start()
    {
        currentY = this.transform.position.y;
        prevY = currentY;
        activated = false;
        mouseOver = false;
    }

    private void Activation()
    {
        GetComponent<Animator>().SetTrigger("Activate");
        activated = true;
        ai = AI();
        StartCoroutine(ai);
    }

    private void DeActivation()
    {
        // GetComponent<Animator>().SetTrigger("Activate");
        activated = false;
        StopCoroutine(ai);
        GetComponent<Animator>().SetTrigger("DeActivate");
        GetComponent<Animator>().ResetTrigger("Jump");
        GetComponent<Animator>().ResetTrigger("Activate");
        GetComponent<Animator>().ResetTrigger("Land");
        GetComponent<Animator>().ResetTrigger("Fall");




    }
    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        if (Input.GetMouseButtonDown(0) && mouseOver)
        {
            if (!activated)
            {
                Activation();
            }
            else
            {
                Debug.Log("deactivate");
                DeActivation();
            }
        }

        currentY = this.transform.position.y;
        yVelocity = currentY - prevY;
        //yVelocity = yVelocity > yVelocityCutOff ? 0 : yVelocity;
        prevY = currentY;
        if (yVelocity < 0)
        {
            GOINGDOWN = true;
            GetComponent<Animator>().SetTrigger("Fall");

        }
        else
        {
            GetComponent<Animator>().ResetTrigger("Fall");
            GOINGDOWN = false;
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

    public void ActivateMe()
    {
        Activation();
    }

    void GroundCheck()
    {
        int layerValue = 8;

        bool prevGrounded = grounded;
        int layer = 1 << layerValue;
        grounded = Physics2D.OverlapArea(topLeft.position, bottomRight.position, layer);// ,layer.value);

        if (grounded == true)
        {

            if (prevGrounded == false)
            {


            }
        }
    }

    public IEnumerator AI()
    {
        yield return new WaitForSeconds(1.5f);
        do
        {

            if (grounded)
            {
                // SFX LAND
                GetComponent<Animator>().SetTrigger("Land");
                yield return new WaitForSeconds(1f);
                GetComponent<Animator>().SetTrigger("Jump");
                // SFX JUMP
                GetComponent<JelloPressureBody>().AddForce((Vector2.up * (forceY + (Random.Range(-100f, 100f) * this.transform.localScale.x))) * this.transform.localScale.x);
                GetComponent<JelloPressureBody>().AddForce((Vector2.right * (forceX + ((Random.Range(-25f, 50f) * this.transform.localScale.x))) * this.transform.localScale.x));


            }

            yield return new WaitForSeconds(0.1f);
        } while (true);

    }
}
