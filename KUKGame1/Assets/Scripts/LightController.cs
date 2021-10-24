using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light;
    public string lightName = "Living room";

    // Start is called before the first frame update
    void Start()
    {
        print("Hello " + lightName);   
    }
    
    private void Awake()
    {
        print("Hello Awake!");
    }
    
    private void OnMouseDown()
    {
        print("Mouse Down");
        if(light.enabled==true){
            light.enabled = false;
        }
        else
        {
            light.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
