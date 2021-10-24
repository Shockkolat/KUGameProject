using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    int count =0;
    // Start is called before the first frame update
    void Start()
    {
        print("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        print(count + "Hello Update!");
        count++;
    }
}
