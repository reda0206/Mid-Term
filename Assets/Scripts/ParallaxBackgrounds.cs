using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgrounds : MonoBehaviour
{
    private float startingPosX;
    private float startingPosY;
    private float lengthOfSprite;
    public float AmountOfParallax;
    public Camera MainCamera;
    
    void Start()
    {
        startingPosX = transform.position.x;
        startingPosY = transform.position.y;
        lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void Update()
    {
        Vector3 cameraPosition = MainCamera.transform.position;
        float TempX = cameraPosition.x * (1 - AmountOfParallax);
        float distanceX = cameraPosition.x * AmountOfParallax;

        float tempY = cameraPosition.y * (1 - AmountOfParallax);
        float distanceY = cameraPosition.y * AmountOfParallax;

        Vector3 newPosition = new Vector3(startingPosX + distanceX, startingPosY + distanceY, transform.position.y, transform.position.z);

        transform.position = newPosition;
    }
}
