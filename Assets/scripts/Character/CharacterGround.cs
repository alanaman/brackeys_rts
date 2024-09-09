using UnityEngine;

//This script is used by both movement and jump to detect when the character is touching the ground

public class CharacterGround : MonoBehaviour
{
    private bool onGround;

[Header("Collider Settings")]
    [SerializeField][Tooltip("Length of the ground-checking collider")] private float groundLength = 0.95f;
    [SerializeField][Tooltip("Distance between the ground-checking colliders")] private float colliderOffset;


[Header("Layer Masks")]
    [SerializeField][Tooltip("Which layers are read as the ground")] private LayerMask groundLayer;

    private Vector3 _colliderOffset1;
    private Vector3 _colliderOffset2;

    private void Start()
    {
        _colliderOffset1 = new Vector3(colliderOffset, 0, colliderOffset);
        _colliderOffset2 = new Vector3(colliderOffset, 0, -colliderOffset);
    }

    private void Update()
    {
        //Determine if the player is stood on objects on the ground layer, using a pair of raycasts
        onGround = 
            Physics.Raycast(transform.position + _colliderOffset1, Vector3.down, groundLength, groundLayer) || 
            Physics.Raycast(transform.position - _colliderOffset1, Vector3.down, groundLength, groundLayer) || 
            Physics.Raycast(transform.position + _colliderOffset2, Vector3.down, groundLength, groundLayer) || 
            Physics.Raycast(transform.position - _colliderOffset2, Vector3.down, groundLength, groundLayer);

    }

    private void OnDrawGizmos()
    {
        //Draw the ground colliders on screen for debug purposes
        if (onGround) { Gizmos.color = Color.green; } else { Gizmos.color = Color.red; }
        Gizmos.DrawRay(transform.position + _colliderOffset1, Vector3.down * groundLength);
        Gizmos.DrawRay(transform.position - _colliderOffset1, Vector3.down * groundLength);
        Gizmos.DrawRay(transform.position + _colliderOffset2, Vector3.down * groundLength);
        Gizmos.DrawRay(transform.position - _colliderOffset2, Vector3.down * groundLength);
    }

    public bool GetOnGround() { return onGround; }

    private void OnValidate()
    {
        _colliderOffset1 = new Vector3(colliderOffset, 0, colliderOffset);
        _colliderOffset2 = new Vector3(colliderOffset, 0, -colliderOffset);
    }
}