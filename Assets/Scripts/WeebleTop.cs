using UnityEngine;
using System.Collections;

public class WeebleTop : MonoBehaviour {
    public WeebleBottom bottom;
    public WeebleMovement movement;

    private ConstantForce constantForce;
    public float upwardsForce;
    public float movingUpwardsForce;
    // Use this for initialization
    void Start ()
    {
        bottom = GetComponentInParent<WeebleBottom>();
        movement = GetComponentInParent<WeebleMovement>();
        if (!bottom) Debug.LogWarning("NO BOTTOM ATTACHED!");
        if (!movement) Debug.LogWarning("NO MOVEMENT ATTACHED!");
        constantForce = GetComponent<ConstantForce>();
	}
	
	// Update is called once per frame
	void Update () {
        if (bottom.IsGrounded())
        {
            constantForce.force = new Vector3(0, movement.isMoving ? movingUpwardsForce : upwardsForce, 0);
        }
        else
        {
            constantForce.force = new Vector3(0, 0, 0);
        }
	}
}
