using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    Vector3 mouseposution;
    public float speed = 0.1f;
    
    
    void Start()
    {
       

    }

    
    void Update()
    {
        mouseposution = Input.mousePosition;
        mouseposution.z = speed;
        transform.position = Camera.main.ScreenToWorldPoint(mouseposution);
        
    }
    
}
