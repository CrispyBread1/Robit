using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{   
    // followspeed is the speed in which the camera follows
    public float FollowSpeed = 2f;
    //cameraYoffsetposition is a varibale used to adjust the camera height
    public float cameraYoffsetposition = 2f;
    // targer = player/character
    public Transform target;

    // Update is called once per frame
    void Update()
    {   
        // characterPostion is the character and uses the target variable to track teh postion (-10f because it is 2d)
        // slerp = spherical interpolation which allows the camera to smoothly follow the target (character)
        Vector3 characterPosition = new Vector3(target.position.x, target.position.y + cameraYoffsetposition, -10f);
        transform.position= Vector3.Slerp(transform.position, characterPosition, FollowSpeed * Time.deltaTime);
    }
}
