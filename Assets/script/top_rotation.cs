using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top_rotation : MonoBehaviour
{
    public float rot_speed = 30.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
            float degrees_per_frame = rot_speed * Time.deltaTime;
            float top_angle = Input.GetAxis("Horizontal");
            this.transform.Rotate(0.0f, top_angle * degrees_per_frame, 0.0f);
     
        

    }

}
