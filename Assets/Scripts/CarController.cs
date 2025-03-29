using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    [SerializeField] private GameObject CarBody;
    [SerializeField] private GameObject TireFrontLeft;
    [SerializeField] private GameObject TireFrontRight;
    [SerializeField] private GameObject Crack;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;
    //private Vector3 Movement;
    public Vector3 tireVector;
    public float MoveSpeed = 1;
    public float Speed = 0.5f;
    public float Acceleration = 0.5f;
    public float BrakeForce = 0.5f;
    public float TurnSpeed = 0.5f;
    public float MaxTireTurn = 30f;
    public float steerAngle = 0;
    public bool alive = true;
    public bool LevelWin = false;

    private void Start()
    {
        alive = true;
        LevelWin = false;
        Speed = 0;
        Crack.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (alive && !LevelWin)
        {
            Crack.GetComponent<SpriteRenderer>().enabled = false;
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            //Turning and Wheel Animation
            steerAngle = Mathf.Lerp(steerAngle, horizontalInput * MaxTireTurn, Time.deltaTime * TurnSpeed);

            tireVector = new Vector3(0, 0, -steerAngle);



            if (verticalInput == 0)
            {
                if (Speed >= 0f && Speed <= 3f)
                {
                    Speed = 0;
                }
                else
                {
                    Speed += (BrakeForce * -Mathf.Sign(Speed));
                }
            }
            else
            {
                if (Mathf.Sign(Speed) == verticalInput)
                {
                    Speed += Acceleration * verticalInput;
                }
                else
                {
                    Speed += Acceleration * verticalInput * 2;
                }
            }


            TireFrontLeft.transform.localEulerAngles = tireVector;
            TireFrontRight.transform.localEulerAngles = tireVector;

            rb.velocity = Speed * transform.up;
            rb.angularVelocity = -steerAngle * Speed;

            /*//Vertical Movement
            if (verticalInput > 0)
            {
                rb.velocity = tireVector.z * Vector2.up;
            }
            else if (verticalInput < 0)
            {
                rb.velocity = tireVector.z * Vector2.up;
            }
            else if (verticalInput == 0)
            {
                rb.velocity = Vector2.zero;
            }*/
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            Speed = 0;
            if (!alive)
            {
                Crack.GetComponent<SpriteRenderer>().enabled = true;

                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(collision);
        if (other.gameObject.layer == 6)
        {
            alive = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        ParkingArea parkingArea = collider.GetComponent<ParkingArea>();

        if (parkingArea != null)
        {
            BoxCollider2D winBox = parkingArea.WinBox;

            if (alive && winBox.bounds.Contains(boxCollider.bounds.min) && winBox.bounds.Contains(boxCollider.bounds.max))
            {
                LevelWin = true;
            }
        }
    }

}
