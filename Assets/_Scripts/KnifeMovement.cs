using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [SerializeField]
    private float jumpCooldown = 1f;
    private float jumpTimer = 0;
    [SerializeField]
    private bool isFlip = false;
    [SerializeField]
    [Range(0f, 5f)] float lerpTime;
    [SerializeField]
    Vector3 myAngles;
    private float t = 0f;
    private CharacterController characterController;
    private Vector3 knifeVelocity;
    [SerializeField]
    private float jumpHeight = 25f;
    private float gravity = -9.81f;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        myAngles = new Vector3(225, 0, 0);
    }

    
    void Update()
    {
        
        
       transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(myAngles), lerpTime * Time.deltaTime);

       t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
       knifeFlip();

       if(myAngles.x >= 360)
        {
            myAngles.x = 0;
        }

    }

    void knifeFlip()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > jumpTimer)
        {
            jumpTimer = Time.time + jumpCooldown;
            isFlip = true;
            knifeVelocity.y += Mathf.Sqrt(jumpHeight * (gravity-15) * -1.0f);
            
                }
        knifeVelocity.y += (gravity-20) * Time.deltaTime;
        characterController.Move(knifeVelocity * Time.deltaTime);
        if (isFlip == true && myAngles.x >= 100 && myAngles.x <= 360)
        {
            myAngles += new Vector3(600 * Time.deltaTime, 0, 0);
        }
        else if(isFlip == true && myAngles.x <=90 && myAngles.x >= 0)
        {
            myAngles += new Vector3(550 * Time.deltaTime, 0, 0);
        }

        else if (isFlip == true && myAngles.x > 90 && myAngles.x < 100)
        {
            myAngles += new Vector3(500 * Time.deltaTime, 0, 0);
            if (myAngles.x > 100)
            {
                isFlip = false;
            }
        }

        
    }
    




}
