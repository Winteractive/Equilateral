using UnityEngine;
using System.Collections;

public class CloudMaker : MonoBehaviour
{


    public Sprite cloudOne;
    public Sprite cloudTwo;
    public Sprite cloudThree;
    public Sprite cloudFour;

    GameObject[] clouds;

    // Use this for initialization
    void Start()
    {
        clouds = GameObject.FindGameObjectsWithTag("Cloud");
        for (int i = 0; i < clouds.Length; i++)
        {
            int random = Random.Range(1, 5);
            int newrandom = 0;
            for (int j   = 0; j < random; j++)
            {
                newrandom = Random.Range(1, 5);
            }

            switch (random)
            {
                case 1:
                    clouds[i].GetComponent<SpriteRenderer>().sprite = cloudOne;
                    break;
                case 2:
                    clouds[i].GetComponent<SpriteRenderer>().sprite = cloudTwo;
                    break;
                case 3:
                    clouds[i].GetComponent<SpriteRenderer>().sprite = cloudThree;
                    break;
                case 4:
                    clouds[i].GetComponent<SpriteRenderer>().sprite = cloudFour;
                    break;
                default:
                    break;
            }
        }
    }


}
