using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class rubycontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position
        position.x = position.x + 0.1f;
        transform.position = position;
    }
}
//this line is there to tell me the x position of my object

/*hi there!
 * this is two lines
 * */
Debug.Log(transform.position.x);

if (transform.position.x <= 5f)
{
    Debug.Log("I'm about to hit the ground!");
}