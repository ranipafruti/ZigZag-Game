using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{

    [SerializeField] private float velocitySpeed;
    [SerializeField] private GameObject diamondParticle;
    [SerializeField] private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 1.0f))
        {
            GameManager.Instance.GameOver();
            rb.constraints = RigidbodyConstraints.None;
            rb.velocity = new Vector3(0, -25, 0);
        }

        if (!GameManager.Instance.isballMovementStarted && Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.isballMovementStarted = true;
            rb.velocity = new Vector3(velocitySpeed, 0, 0);
        }

        else if (Input.GetMouseButtonDown(0) && !GameManager.Instance.isGameOver)
        {
            SwitchDirection();
        }
    }
    private void SwitchDirection()
    {
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, velocitySpeed);
        }

        else if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(velocitySpeed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Coin")
        {
            GameManager.Instance.Increasescore();

            GameObject part = Instantiate(diamondParticle, other.gameObject.transform.position, diamondParticle.transform.rotation);

            Destroy(part, 1);
            Destroy(other.gameObject);
        }
    }
}
