using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject knife;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = knife.transform.position + new Vector3(11.5f - 4.13f, 15.7f - 10.83f, -7.7f);
    }
}
