using UnityEngine;
using System.Collections;

public class WeebleBottom : MonoBehaviour
{
    //public bool isGrounded;
    private bool isRaycastGrounded;
    private bool isCollisionGrounded;
    void Update()
    {
        Vector3 downward = transform.TransformDirection(Vector3.down) * 10f;
        if(Physics.Raycast(transform.position, Vector3.down, 3f))
        {
            isRaycastGrounded = true;
        }
        else
        {
            isRaycastGrounded = false;
        }
        Debug.DrawRay(transform.position, downward, Color.green);
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        isCollisionGrounded = true;
        //if (collisionInfo.transform.tag == "ground")
        //{
        //    isCollisionGrounded = true;
        //}
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        isCollisionGrounded = false;
    }

    public bool IsGrounded()
    {
        return isCollisionGrounded && isRaycastGrounded;
    }
}