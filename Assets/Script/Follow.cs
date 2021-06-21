using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float distance = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zCordinate =  target.position.z - distance;
        transform.position = new Vector3(target.position.x, target.position.y, zCordinate);
    }
}
