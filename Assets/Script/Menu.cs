using UnityEngine;
using UnityEngine.UI;

public class ObjectCountController : MonoBehaviour
{
    public Text objectCountText; // Reference to the text displaying the object count
    public int defaultObjectCount = 16; // Default number of objects
    public GameObject barrel; // Reference to the barrel object or its script

    private int numObjects;

    private void Start()
    {
        numObjects = defaultObjectCount;
        UpdateObjectCountText();
    }

    public void IncreaseObjects()
    {
        numObjects += 2;
        UpdateObjectCountText();
        UpdateBarrelObjectCount();
    }

    public void DecreaseObjects()
    {
        if (numObjects > 2)
        {
            numObjects -= 2;
            UpdateObjectCountText();
            UpdateBarrelObjectCount();
        }
    }

    private void UpdateObjectCountText()
    {
        objectCountText.text = numObjects.ToString();
    }

    private void UpdateBarrelObjectCount()
    {
        // Access the barrel object or its script and update the object count
        // Example: barrel.GetComponent<BarrelScript>().SetObjectCount(numObjects);
    }
}