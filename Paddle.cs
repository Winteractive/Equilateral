using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{


    public enum ControlMethod { Mouse, Touch };
    public ControlMethod ctrlMethod;


    public float speedBuildUpSpeed;
    public float speedBuildUp;
    public float speedLimit;
    public float speedLossFromTurning;

    public bool goLeft;
    public bool goRight;

    public float velocityLimiter;
    public bool PaddlePressed;
    public bool mouseOver;

    public float velocity;
    public float prevX;
    public float currentX;
    public float startY;
    public float str;
    Vector2 startScale;
    Vector2 startScaleSprite;


    public Transform LeftTarget;
    public Transform rightTarget;

    public float distanceSpeedLimiter;
    public float distanceToMouse;

    public float speed;
    // Use this for initialization
    void Start()
    {

        startY = this.transform.position.y;
        startScale = this.transform.localScale;
        // startScaleSprite = GetComponent<SpriteMeshLink>().scale;
        mouseOver = false;
        PaddlePressed = false;
        currentX = this.transform.position.x;
        prevX = currentX;

    }

    // Update is called once per frame
    void Update()
    {

        distanceToMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x;
        distanceToMouse = distanceToMouse < 0 ? -distanceToMouse : distanceToMouse;
        distanceSpeedLimiter = distanceToMouse / 10;
        distanceSpeedLimiter -= 0.2f;
        distanceSpeedLimiter = distanceSpeedLimiter > 1 ? 1 : distanceSpeedLimiter;
        distanceSpeedLimiter = distanceSpeedLimiter < 0 ? 0 : distanceSpeedLimiter;

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * str);

        }
        currentX = this.transform.position.x;
        velocity = currentX - prevX;
        velocity = velocity < 0 ? -velocity : velocity;
        prevX = currentX;

        velocity = velocity > velocityLimiter ? velocityLimiter : velocity;

        this.transform.localScale = Vector2.Lerp(this.transform.localScale, new Vector2(startScale.x * (1 + velocity), startScale.y * (1 - velocity)), Time.deltaTime * 20);
        //   GetComponent<SpriteMeshLink>().scale = new Vector2(startScaleSprite.x * (1 + velocity), startScaleSprite.y * (1 - velocity));

        if (goLeft || goRight)
        {

            speedBuildUp += Time.deltaTime * speedBuildUpSpeed;
            speedBuildUp = speedBuildUp > speedLimit ? speedLimit : speedBuildUp;
            if (goLeft)
            {
                this.transform.position -= new Vector3(Time.deltaTime * speedBuildUp, 0);
            }
            else if (goRight)
            {
                this.transform.position += new Vector3(Time.deltaTime * speedBuildUp, 0);
            }
        }
        else
        {
            speedBuildUp = 0;
        }



        Limiter();
    }


    void Limiter()
    {


        this.transform.position = new Vector2(this.transform.position.x, startY);
        this.transform.position = new Vector2(this.transform.position.x < LeftTarget.transform.position.x ? LeftTarget.transform.position.x : this.transform.position.x, this.transform.position.y);
        this.transform.position = new Vector2(this.transform.position.x > rightTarget.transform.position.x ? rightTarget.transform.position.x : this.transform.position.x, this.transform.position.y);

    }

    void OnMouseEnter()
    {
        mouseOver = true;
    }

    public void LeftPressed()
    {
        goLeft = true;
        goRight = false;
    }

    public void LeftExited()
    {
        speedBuildUp -= speedLossFromTurning;
        goLeft = false;
    }

    public void RightExited()
    {
        speedBuildUp -= speedLossFromTurning;
        goRight = false;
    }


    public void RightPressed()
    {
        goLeft = false;
        goRight = true;
    }




    void OnMouseExit()
    {
        mouseOver = false;
    }
}
