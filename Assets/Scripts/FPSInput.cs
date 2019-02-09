using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {

    public float moveSpeed = 2f;
    public float gravity = -9f;

    private CharacterController _charController;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update () {
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
        float deltaZ = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 movment = new Vector3(deltaX, 0, deltaZ);
        movment = Vector3.ClampMagnitude(movment, moveSpeed); // Limit diagonal movment to the same speed as movement along an axis.
        movment.y = gravity;

        movment *= Time.deltaTime;
        movment = transform.TransformDirection(movment); //Transforms the movement vector from local to global coordinates
        _charController.Move(movment); // Tell the characterController to move by that vector.
	}
}
