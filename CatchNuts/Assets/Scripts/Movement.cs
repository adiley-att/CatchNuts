using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool facingLeft;

    float sprtSize;

    Vector2 screenBounds;

    public Animator anim;
    public SpriteRenderer sprt;

    void Start()
    {
        facingLeft = true;

        sprtSize = sprt.bounds.size.x / 4; 

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {

            transform.Translate(Vector3.left * 5 * Time.deltaTime);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, screenBounds.x * -1 + sprtSize, screenBounds.x - sprtSize),
                transform.position.y , 0);

            anim.SetBool("Moving", true);

            if (Input.mousePosition.x > Screen.width / 2)
            {
                if (facingLeft)
                {
                    facingLeft = !facingLeft;
                    transform.Rotate(0, 180, 0); 
                }
            }

            if (Input.mousePosition.x < Screen.width / 2)
            {
                if (!facingLeft)
                {
                    facingLeft = !facingLeft;
                    transform.Rotate(0, -180, 0); 
                }
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Moving", false);
        }
    }
}
