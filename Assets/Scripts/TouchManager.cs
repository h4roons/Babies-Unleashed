using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    public GameObject obstacle; 
    PlayerInput playerInput;
    InputAction primaryTouch;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        primaryTouch = playerInput.actions["primaryTouch"];
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        primaryTouch.performed+= OnTouchStarted;
    }

    void OnDisable()
    {
        primaryTouch.performed -= OnTouchStarted;
    }

    private void OnTouchStarted(InputAction.CallbackContext context)
    {
        if (primaryTouch.WasPerformedThisFrame())
        {
            Vector2 touchPosition = Touchscreen.current.touches[0].position.ReadValue();
            Debug.Log("Touch Position: " + touchPosition);

            Vector3 worldTouchPosition = GetWorldTouchPosition(touchPosition);
            Debug.Log("World Touch Position: " + worldTouchPosition);

            Instantiate(obstacle, worldTouchPosition, Quaternion.identity);
        }
    }

    private Vector3 GetWorldTouchPosition(Vector2 touchPos)
    {
        Ray touchRay = Camera.main.ScreenPointToRay(touchPos);

        float distanceToGround = -touchRay.origin.y / touchRay.direction.y;

        return touchRay.GetPoint(distanceToGround);
    }
}
