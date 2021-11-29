/*
 * written by Joseph Hocking 2017
 * released under MIT license
 * text of license https://opensource.org/licenses/MIT
 * 
 * Modified and expanded by Kevin Chao, 2021
 */

using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

// basic WASD-style movement control
public class FpsMovement : MonoBehaviour {
    [SerializeField] private Camera headCam;

    public float speed = 6.0f;
    public float gravity = -9.8f;

    public float sensitivityHor = 5.5f;
    public float sensitivityVert = 5.5f;

    public float minimumVert = -60.0f;
    public float maximumVert = 60.0f;

    private float rotationVert = 0;

    private CharacterController charController;


    void Start() {
        charController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update() {
        MoveCharacter();
        RotateCharacter();
        RotateCamera();
    }


    private void MoveCharacter() {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        Physics.SyncTransforms();
        charController.Move(movement);
    }


    private void RotateCharacter() {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
    }


    private void RotateCamera() {
        rotationVert -= Input.GetAxis("Mouse Y") * sensitivityVert;
        rotationVert = Mathf.Clamp(rotationVert, minimumVert, maximumVert);

        headCam.transform.localEulerAngles = new Vector3(rotationVert, headCam.transform.localEulerAngles.y, 0);
    }


    public float getVelocity() {
        Vector3 horizontalVelocity = new Vector3(charController.velocity.x, 0, charController.velocity.z);

        return horizontalVelocity.magnitude;
    }
}