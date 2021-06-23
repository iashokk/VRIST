using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed;
    public float angle;
    public Vector3 direction;
    bool inhand = false;
    // Start is called before the first frame update
    void Start()
    {
        angle = transform.eulerAngles.y; 
    }

    // Update is called once per frame
    void Update()
    {

        {
          

                if (Mathf.Round(transform.eulerAngles.y) != angle)


            {
                transform.Rotate(direction * speed);
            }




            if (Input.GetButtonDown("Fire1"))
            {
                angle = 360;
                direction = Vector3.up;
            }
            



        }  } }
