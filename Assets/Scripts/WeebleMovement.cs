using UnityEngine;
using System.Collections;


public class WeebleMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float jumpForce;
    private WeebleBottom bottom;
    private Rigidbody rb;
    public bool isMoving;
    private PlayerModelManager playerManager;

    public GameManager manager;
    public SoundManager sounds;
    // Use this for initialization
    void Start()
    {
        bottom = GetComponentInChildren<WeebleBottom>();
        rb = bottom.GetComponent<Rigidbody>();
        playerManager = GetComponent<PlayerModelManager>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sounds = GameObject.FindGameObjectWithTag("GameManager").GetComponentInChildren<SoundManager>();
        rb.angularDrag = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // If moving, lower drag
        if (isMoving)
        {
            rb.drag = GetMovingDrag();
        }
        else
        {
            rb.drag = GetNormalDrag();
            //rb.drag = 0.8f;
        }
        //Jump
        if (bottom.IsGrounded())
        {
            if (Input.GetButtonDown("Jump_" + playerManager.player))
            {
                rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical_" + playerManager.player);
        float h = Input.GetAxis("Horizontal_" + playerManager.player);
        if (bottom.IsGrounded())
        {

            // free movement
            float hSpeed = h * this.moveSpeed;
            float vSpeed = v * this.moveSpeed;

            rb.AddForce(Vector3.forward * vSpeed, ForceMode.Force);
            rb.AddForce(Vector3.right * hSpeed, ForceMode.Force);

            isMoving = v != 0;
            //rb.AddForce(Vector3.right * hSpeed, ForceMode.Force);

            // forward movement only
            //float moveSpeed = Mathf.Max(Mathf.Abs(v), Mathf.Abs(h)) * this.moveSpeed;
            //if (moveSpeed > 0)
            //{
            //    rb.AddForce(Vector3.forward * this.moveSpeed, ForceMode.Force);
            //}



            //Debug.Log(v + " " + h);
        }
        else
        {
            isMoving = false;
        }

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 1, 0) * Time.deltaTime * rotationSpeed);


        Vector3 targetDir = new Vector3(transform.position.x + h, transform.position.y, transform.position.z + v) - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        //Debug.Log("angle: " + angle);

        if (angle > 60f)
        {

            rb.AddRelativeTorque(new Vector3(0,v + h, 0) * Time.deltaTime * rotationSpeed, ForceMode.VelocityChange);
            //rb.MoveRotation(rb.rotation * deltaRotation);
        }

    }

    public float GetNormalDrag()
    {
        switch (manager.currentLevel) {
            case Level.Desert:
                return 1f;
            case Level.Ice:
                return 0.2f;
            case Level.Rock:
                return 0.8f;
            case Level.Metal:
                return 0.8f;
        }
        return 0.5f;
    }

    public float GetMovingDrag()
    {
        switch (manager.currentLevel)
        {
            case Level.Desert:
                return 1.3f;
            case Level.Ice:
                return 0.5f;
            case Level.Rock:
                return 0.7f;
            case Level.Metal:
                return 0.8f;
        }
        return 0.6f;
    }
}
