using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;
    // Start is called before the first frame update
   private void LateUpdate()
    {
        //get the camera position
        Vector3 cameraPosition = _mainCamera.transform.position;
        //We only want to rotate on the _ axis:
        cameraPosition.y = transform.position.y;
        //make the sprite face the camera
        transform.LookAt(cameraPosition);
        //rotate 180 on y because of how SpriteRenderer works
        transform.Rotate(0f,180f,0f);
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
