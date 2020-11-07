using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform y;

    public Transform z;

    public bool vai;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vai)
        {
            transform.position = Vector3.MoveTowards(transform.position, z.position, Time.deltaTime * 8);
        }
    }
}
