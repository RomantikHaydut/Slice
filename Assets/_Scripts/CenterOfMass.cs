using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{

    public Vector3 mass;
    public Rigidbody body;
    [SerializeField]
    protected bool awake;
    void Start()
    {
        
        body = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        body.centerOfMass = mass;
        body.WakeUp();
        awake = !body.IsSleeping();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + transform.rotation * mass, 1);
    }
}
