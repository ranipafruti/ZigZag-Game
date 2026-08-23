using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float lerpRate;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (!GameManager.Instance.isGameOver)
        {
            FollowBall();
        }
    }

    private void FollowBall()
    {

        // transform.position = ball.transform.position - offset;    

        Vector3 currentpos = transform.position;
        Vector3 targetpos = ball.transform.position - offset;

        transform.position = Vector3.Lerp(currentpos, targetpos, lerpRate * Time.deltaTime);
    }
}
