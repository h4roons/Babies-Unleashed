using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    public GameObject obstacle;


    private Vector3 GetWorldTouchPosition(Vector2 touchPos)
    {
        Ray touchRay = Camera.main.ScreenPointToRay(touchPos);

        float distanceToGround = -touchRay.origin.y / touchRay.direction.y;

        return touchRay.GetPoint(distanceToGround);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 touchPosition = Touchscreen.current.touches[0].position.ReadValue();
            Debug.Log("Touch Position: " + touchPosition);

            Vector3 worldTouchPosition = GetWorldTouchPosition(touchPosition);
            Debug.Log("World Touch Position: " + worldTouchPosition);
            if (touchPosition != null)
            {
                    
                    Instantiate(obstacle, worldTouchPosition, Quaternion.identity);
                    // Messenger.Broadcast(GameEvent.obstacleInstantiated);
                    Debug.Log("Instantiated" + transform.name);
                
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            gameObject.SetActive(false);
        }
    }
}
