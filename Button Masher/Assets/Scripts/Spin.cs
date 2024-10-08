using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Spin : MonoBehaviour
{


    // Start is called before the first frame update
    void Update()
       
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = GetTouchWorldPosition();

            touchPosition.z = transform.position.z;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    transform.position = touchPosition;
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    transform.position = Vector3.Lerp(transform.position,touchPosition, Time.deltaTime * 5f);
                    break;
            }

        }




        transform.Rotate(0f, 1f, 0f, Space.Self);
    }


    Vector3 GetTouchWorldPosition()
    {
        Vector3 touchPosScreen = Input.GetTouch(0).position;

        Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPosScreen.x, touchPosScreen.y, Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));

        return touchPosWorld;
    }
}
