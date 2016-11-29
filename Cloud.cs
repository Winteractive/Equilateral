using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
    public float speed;

    public Vector2 startSize;
    Vector2 lerpSize;
    public float sortingOrder;
    // Use this for initialization
    void Start()
    {
        StartScaleEtc();
    }


    private void StartScaleEtc()
    {
        this.transform.localScale = Vector3.one;
        speed = 0.1f;
        float randomSize = Random.Range(0.4f, 1f);
        this.transform.localScale = Vector2.Scale(this.transform.localScale, new Vector2(randomSize, randomSize));
        startSize = this.transform.localScale;
        lerpSize = startSize;
        StartCoroutine(Reshape());
        this.GetComponent<SpriteRenderer>().sortingOrder = -(int)(-10 - (this.transform.localScale.x * 10)) - 30;
        this.transform.position += new Vector3(0, 10 * (this.transform.localScale.x - 1));


    }
    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = Vector2.Lerp(this.transform.localScale, lerpSize, Time.deltaTime * 1);
        this.transform.position += new Vector3(-1 * Time.deltaTime * ((this.GetComponent<SpriteRenderer>().sortingOrder * 2) * -speed), 0);
        if (this.transform.position.x < -28)
        {
            this.transform.position = new Vector3(Random.Range(28, 36), 6);
            StartScaleEtc();
        }
    }

    public IEnumerator Reshape()
    {
        do
        {
            lerpSize = Vector2.Scale(startSize, new Vector2(Random.Range(0.7f, 1f), Random.Range(0.7f, 1)));
            yield return new WaitForSeconds(Random.Range(0.3f, 0.7f));
        } while (true);
        yield break;
    }
}
