using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ClickableObject : MonoBehaviour
{
    private TurnManager turnManager;
    
    public AudioSource nifeSound;
    public AudioSource endSound;
    
    public Rigidbody zombie;
    
    public Camera mainCamera;
    public GameObject objectToMove;
    private float moveSpeed = 7f;

    public Color highlightColor = Color.yellow;
    private Color originalColor;
    private Renderer objectRenderer;

    private bool isMoving = false;
    private bool isClicked = false;
    public bool isSpecialObject = false;
    private Vector3 targetPosition;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        turnManager = TurnManager.FindObjectOfType<TurnManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isClicked)
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isMoving = true;
                    isClicked = true;
                    targetPosition = hit.point;
                    objectRenderer.material.color = originalColor;
                }
            }
        }

        if (isMoving)
        {
            objectToMove.gameObject.SetActive(true);
            nifeSound.Play();
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(objectToMove.transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
            
            if (isSpecialObject)
            {
                objectRenderer.material.color = Color.red;
                endSound.Play();
                zombie.isKinematic = false;
                Vector3 zombieTarget = mainCamera.transform.position + mainCamera.transform.forward;
                zombie.position = Vector3.MoveTowards(zombie.position, zombieTarget, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(zombie.position, zombieTarget) < 0.01f)
                {
                    zombie.isKinematic = true;  // Optionally, remove this line
                }

                turnManager.PlayerLoseDisplay();
            }

            turnManager.UpdateTurnChangePossible();
        }
    }

    private void OnMouseEnter()
    {
        if (!isClicked)
        {
            objectRenderer.material.color = highlightColor;
        }
    }

    private void OnMouseExit()
    {
        if (!isClicked)
        {
            objectRenderer.material.color = originalColor;
        }
    }
}