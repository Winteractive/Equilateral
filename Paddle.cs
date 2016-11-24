using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{


    public enum ControlMethod { Mouse, Touch };
    public ControlMethod ctrlMethod;

    public bool PaddlePressed;
    public bool mouseOver;

    public float speed;
    // Use this for initialization
    void Start()
    {
        mouseOver = false;
        PaddlePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (ctrlMethod)
        {
            case ControlMethod.Mouse:
                if (Input.GetMouseButton(0) && mouseOver)
                {
                    PaddlePressed = true;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    PaddlePressed = false;
                }

                break;
            case ControlMethod.Touch:
                break;
            default:
                break;
        }

        if (PaddlePressed)
        {
            this.transform.position = new Vector2(Mathf.Lerp(this.transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Time.deltaTime * speed), this.transform.position.y);
        }

        Limiter();
    }


    void Limiter()
    {
        this.transform.position = new Vector2(this.transform.position.x < -5.5f ? -5.5f : this.transform.position.x, this.transform.position.y);
        this.transform.position = new Vector2(this.transform.position.x > 4.8f ? 4.8f : this.transform.position.x, this.transform.position.y);

    }

    void OnMouseEnter()
    {
        mouseOver = true;
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }
}
