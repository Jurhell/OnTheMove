using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private MomentumBehavior _momentumBehavior;

    [Tooltip("The current active camera. Used to get mouse position for rotation.")]
    [SerializeField]
    private Camera _camera;

    private Rigidbody _rigidbody;
    private float _moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //Store reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();

        _moveSpeed = GetComponent<MomentumBehavior>().Speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }

    private void FixedUpdate()
    {
        _moveSpeed = _momentumBehavior.Speed;

        //The direction the player is moving in is set to the input values for the horizontal and vertical axis
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //The move direction is scaled by the movement speed to get velocity
        Vector3 velocity = moveDir * _moveSpeed * Time.deltaTime;

        //Call to make the rigidbody smoothly move to the desired position
        _rigidbody.MovePosition(transform.position + velocity);
    }
}
