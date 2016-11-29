using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour
{
    public bool eyesOpen;
    public SpriteRenderer sprRenderer;
    public Sprite startSprite;
    // Use this for initialization
    void Start()
    {

        eyesOpen = true;
        sprRenderer = GetComponent<SpriteRenderer>();
        startSprite = sprRenderer.sprite;
        StartCoroutine(DoBlink());
    }



    public IEnumerator DoBlink()
    {
        Debug.Log("start");
        do
        {
            if (eyesOpen == false)
            {
                yield return new WaitForSeconds(0.15f);
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }


            eyesOpen = !eyesOpen;
            if (eyesOpen)
            {
                sprRenderer.sprite = startSprite;
            }
            else
            {
                sprRenderer.sprite = null;
            }


        } while (true);
        yield break;
    }
}
