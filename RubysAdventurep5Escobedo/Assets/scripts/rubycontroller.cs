using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubycontroller : MonoBehaviour
{
    // Start is called before the first frame update
    //START WORLD INTERACTIONS AT 13:07
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 position = transform.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        transform.position = position;
    }
}