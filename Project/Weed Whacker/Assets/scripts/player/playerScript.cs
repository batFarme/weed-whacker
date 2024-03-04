using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    //references
    public InputAction controlMovement;
    public Rigidbody2D myRigidBody2D;
    public GameObject myHitbox;
    public GameObject myHurtbox;

    //handling
    public float moveSpeed;

    //internal control variables
    private delegate void crntStateExecute();
    crntStateExecute crntState;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        crntState = standingState;
    }

    private void OnEnable()
    {
        controlMovement.Enable();
    }
    private void OnDisable()             // the guy in the video said to put these in... whatever they do
    {
        controlMovement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        crntState();
    }

    private void stateTransition(string stateName)  //rather than simply setting the crntState var in code directly, use this (future-proofing)
    {

    }
    // states; when set as crntState, they are called every frame
    private void standingState() //stateName is standingState
    {
        moveDirection = controlMovement.ReadValue<Vector2>();
        myRigidBody2D.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); //movement
    }

    private void knockedState() //stateName is knockedState
    {

    }

    private void deadState() //stateName is deadState
    {

    }
}
