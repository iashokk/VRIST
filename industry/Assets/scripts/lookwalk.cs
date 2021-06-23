using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookwalk : MonoBehaviour
{
    public Transform vrcamera;
    public float toggleangle = 30.0f;
    public float speed = 3.0f;
    public bool moveforward;

    private CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vrcamera.eulerAngles.x >= toggleangle && vrcamera.eulerAngles.x < 90.0f)
          {
            moveforward = true;
        }  
        else
        {
            moveforward = false;
        }

        if(moveforward)
        {
            Vector3 forward = vrcamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward* speed);
        }
          
    }
}
