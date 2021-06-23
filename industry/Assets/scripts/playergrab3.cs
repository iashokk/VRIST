using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playergrab3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public GameObject myhands;
    Vector3 ballpos;

    bool inhand = false;



    void Start()
    {

        ballpos = ball.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {


            if (!inhand)
            {
                ball.transform.SetParent(myhands.transform);

                ball.transform.localPosition = new Vector3(0f, -.672f, 0f);
                inhand = true;

            }
            else if (inhand)
            {
                this.GetComponent<playergrab>().enabled = false;
                ball.transform.SetParent(null);
                ball.transform.localPosition = ballpos;
                inhand = false;




            }
        }
    }
}
