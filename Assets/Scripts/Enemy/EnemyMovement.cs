using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 50f;
    public float rotationSpeed = 720f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isMoving = true;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight)
        {
            transform.Rotate(new Vector3(0,0,rotationSpeed * Time.deltaTime));
        }
        if(isRotatingLeft)
        {
            transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime)); //transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        rb.AddForce(transform.up * movementSpeed * Time.deltaTime);
    }
    IEnumerator Wander()
    {
        float rotationTime = Random.Range(0.1f,2.0f);
        float rotateWait = Random.Range(0.1f, 2.0f);
        float rotateDirection = Random.Range(1,3);
        //float moveWait = Random.Range(1,3);
        //float moveTime = Random.Range(1,3);

        isWandering = true;

        //yield return new WaitForSeconds(moveTime);

        //yield return new WaitForSeconds(moveWait);


        yield return new WaitForSeconds(rotateWait);

        if(rotateDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }


        if (rotateDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        isWandering = false;
    }
}
