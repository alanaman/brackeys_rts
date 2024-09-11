using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask groundLayer;
    Rigidbody rb;
    CharacterGround ground;


    [Header("Movement Stats")]
    [SerializeField, Range(0f, 20f)][Tooltip("Maximum movement speed")] public float maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)][Tooltip("How fast to reach max speed")] public float maxAcceleration = 52f;
    [SerializeField, Range(0f, 100f)][Tooltip("How fast to stop after letting go")] public float maxDecceleration = 52f;
    [SerializeField, Range(0f, 100f)][Tooltip("How fast to stop when changing direction")] public float maxTurnAcceleration = 80f;
    [SerializeField, Range(0f, 100f)][Tooltip("How fast to reach max speed when in mid-air")] public float maxAirAcceleration;
    [SerializeField, Range(0f, 100f)][Tooltip("How fast to stop in mid-air when no direction is used")] public float maxAirDeceleration;
    [SerializeField, Range(0f, 100f)][Tooltip("How fast to stop when changing direction when in mid-air")] public float maxAirTurnAcceleration = 80f;

    [Header("Options")]
    [Tooltip("When false, the charcter will skip acceleration and deceleration and instantly move and stop")] public bool useAcceleration;

    [Header("Calculations")]
    Vector2 inpuDir;
    private Vector3 desiredVelocity;
    private Vector3 velocity;
    private float acceleration;
    private float deceleration;
    private float turnAcceleration;
    float maxSpeedChange;

    [Header("Current State")]
    public bool onGround;
    public bool pressingKey;


    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        ground = GetComponentInChildren<CharacterGround>();
    }

    // Update is called once per frame
    void Update()
    {
        ////Used to stop movement when the character is playing her death animation
        //if (!moveLimit.characterCanMove && !itsTheIntro)
        //{
        //    directionX = 0;
        //}

        //Used to flip the character's sprite when she changes direction
        //Also tells us that we are currently pressing a direction button
        if (inpuDir.magnitude != 0)
        {
            pressingKey = true;
        }
        else
        {
            pressingKey = false;
        }

        desiredVelocity = (new Vector3(inpuDir.x, 0f, inpuDir.y)).normalized * maxSpeed;
    }

    private void FixedUpdate()
    {
        //Fixed update runs in sync with Unity's physics engine

        //Get Kit's current ground status from her ground script
        //Check if we're on ground, using Kit's Ground script
        onGround = ground.GetOnGround();

        //Get the Rigidbody's current velocity
        velocity = rb.velocity;

        //Calculate new velocity
        if (useAcceleration)
        {
            runWithAcceleration();
        }
        else
        {
            if (onGround)
            {
                runWithoutAcceleration();
            }
            else
            {
                runWithAcceleration();
            }
        }

        rb.velocity = velocity;
    }

    public void SetMovementDirection(Vector2 direction)
    {
        inpuDir = direction;
    }
    private void runWithoutAcceleration()
    {
        //If we're not using acceleration and deceleration, just send our desired velocity (direction * max speed) to the Rigidbody
        velocity.x = desiredVelocity.x;
        velocity.z = desiredVelocity.z;
    }

    private void runWithAcceleration()
    {
        //Set our acceleration, deceleration, and turn speed stats, based on whether we're on the ground on in the air

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        deceleration = onGround ? maxDecceleration : maxAirDeceleration;
        turnAcceleration = onGround ? maxTurnAcceleration : maxAirTurnAcceleration;

        maxSpeedChange = 0;

        if (pressingKey)
        {
            //If the sign (i.e. positive or negative) of our input direction doesn't match our movement, it means we're turning around and so should use the turn speed stat.
            if (Vector2.Dot(inpuDir, velocity.xz()) < 0)
            {
                maxSpeedChange = turnAcceleration * Time.deltaTime;
            }
            else
            {
                //If they match, it means we're simply running along and so should use the acceleration stat
                maxSpeedChange = acceleration * Time.deltaTime;
            }
        }
        else
        {
            //And if we're not pressing a direction at all, use the deceleration stat
            maxSpeedChange = deceleration * Time.deltaTime;
        }

        //TODO: make this normalized
        //Move our velocity towards the desired velocity, at the rate of the number calculated above
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

    }

}
