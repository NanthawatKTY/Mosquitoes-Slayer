using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBob : MonoBehaviour
{

    Vector3 characterScale;
    float characterScaleX;

    // Start is called before the first frame update
    void Start()
    {
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    private void Flip()
    {
        // Move the Character:
        //transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);

        // Flip the Character:
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            characterScale.x = -characterScaleX;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            characterScale.x = characterScaleX;
        }
        transform.localScale = characterScale;

    }
}
