using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{

    private Vector3 endPos;
    private float moveSpeed = 5.0f;
    private float dist;

    private string lastInput;

    private string currenntInput;
    
    // Start is called before the first frame update
    void Start()
    {
        endPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            lastInput = "w";
        }
        else if (Input.GetKeyDown("a"))
        {
            lastInput = "a";
        }
        else if (Input.GetKeyDown("s"))
        {
            lastInput = "s";

        }
        else if (Input.GetKeyDown("d"))
        {
            lastInput = "d";
        }
        movePlayer(); 
        
    } // end Update()

    void movePlayer()
    {
        
        dist = Vector3.Distance(transform.position, endPos);
        //Debug.Log(dist);

        if (lastInput == "w")
        {
            if (dist < 0.2f) // Delay the user input (change when finish lerping)
            { 
                endPos = new Vector3(transform.position.x, transform.position.y + 1.0f); 
            }
            transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * moveSpeed);
        }
        else if (lastInput == "a")
        {
            if (dist < 0.2f) 
            { 
                endPos = new Vector3(transform.position.x - 1.0f, transform.position.y); 
            }
            transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * moveSpeed);
        }
        else if (lastInput == "s")
        {
            if (dist < 0.2f) 
            { 
                endPos = new Vector3(transform.position.x, transform.position.y - 1.0f); 
            }
            transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * moveSpeed);
        }
        else if (lastInput == "d")
        {
            if (dist < 0.2f) 
            {
                endPos = new Vector3(transform.position.x + 1.0f, transform.position.y); 
            }
            transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * moveSpeed);
        }

    } // end movePlayer()



}
