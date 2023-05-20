using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHole : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab of the object you want to create
    private int numObjects => PlayerData.Instance.HoleCount; // Number of objects to create
    public float radius; // Radius from the center of the barrel
    private string objectTag = "ClickableObject";
    private List<GameObject> clickableObjects;
    
    private void Start()
    {
        Debug.Log(numObjects);
        float angleIncrement = 360f / numObjects;
        bool useTwoRows = false;
    
        for (int i = 0; i < numObjects; i++)
        {
            float angle = i * angleIncrement;
            Vector3 position = CalculatePosition(angle, useTwoRows, angleIncrement);
            
            // Calculate the rotation so the object faces the center of the barrel
            Vector3 directionToCenter = (transform.position - position).normalized;
            Quaternion holeRotation = Quaternion.LookRotation(directionToCenter);

        
            GameObject newObject = Instantiate(objectPrefab, position, holeRotation);
            newObject.transform.SetParent(transform); // Set the barrel as the parent
            newObject.tag = objectTag;

            Transform swordTransform = newObject.transform.Find("holeSword");
            if (swordTransform != null)
            {
                GameObject sword = swordTransform.gameObject;
                
                Vector3 directionAwayFromCenter = (position - transform.position).normalized;
                float distanceFromNewObject = 2.4f;  // Set this to whatever distance you want
                Vector3 swordPosition = newObject.transform.position + directionAwayFromCenter * distanceFromNewObject;
                sword.transform.position = swordPosition;
                
                Quaternion swordRotation = sword.transform.rotation;
                float zRotation = swordRotation.eulerAngles.z * -1;
                sword.transform.rotation = Quaternion.Euler(swordRotation.eulerAngles.x, swordRotation.eulerAngles.y, zRotation);
            }
            else
            {
                Debug.LogWarning("not found sword");
            }
        }

        CreateSpecialObject();
    }

    private Vector3 CalculatePosition(float angle, bool useTwoRows, float angleIncrement)
    {
        // Convert angle to radians
        float radianAngle = angle * Mathf.Deg2Rad;
    
        // Calculate the position based on the angle and radius
        float x = Mathf.Cos(radianAngle) * radius;
        float y = 0f; // Assuming the barrel is standing vertically
        float z = Mathf.Sin(radianAngle) * radius;
    
        // Adjust the position relative to the barrel's position
        Vector3 position = transform.position + new Vector3(x, y, z);
    
        // If using two rows, adjust the y position based on index
        if (useTwoRows)
        {
            int index = Mathf.FloorToInt(angle / angleIncrement);
            float rowOffset = index % 2 == 0 ? 0.3f : -0.3f;
            position.y += rowOffset;
        }
    
        return position;
    }

    private void CreateSpecialObject()
    {
        clickableObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("ClickableObject"));

        int specialObjectIndex = Random.Range(0, clickableObjects.Count);
        ClickableObject specialObject = clickableObjects[specialObjectIndex].GetComponent<ClickableObject>();
        specialObject.isSpecialObject = true;
    }
}
