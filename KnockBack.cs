using UnityEngine;
using System.Collections;

public class KnockBack : MonoBehaviour
{
    bool doKnock;
    // Use this for initialization
    void Start()
    {
        doKnock = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator DoKnockback(JelloPressureBody body, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        body.gameObject.GetComponent<JelloPressureBody>().AddForce(Vector2.left * 500);
        body.gameObject.GetComponent<JelloPressureBody>().AddForce(Vector2.up * 400);
        yield return new WaitForSeconds(0.1f);
        doKnock = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.GetComponent<JelloPressureBody>())
        {
            if (doKnock != true)
            {
                doKnock = true;
                StartCoroutine(DoKnockback(col.GetComponent<JelloPressureBody>(), 0.6f));
            }
        }

    }
}
