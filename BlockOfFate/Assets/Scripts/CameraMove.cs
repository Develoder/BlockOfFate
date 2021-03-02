using UnityEngine;

[DisallowMultipleComponent, RequireComponent(typeof(Camera))]
public sealed class CameraMove : MonoBehaviour
{
    [Range(0, 10f)] public float moveSpeed = 10f;
    [Range(0f, 5f)] public float sensitivity = 3;
    [Range(0.01f, 2f)] public float sensitivityX = 1f;
    [Range(0.01f, 2f)] public float sensitivityY = 0.6f;
    
    public bool isDragging { get; private set; }
    private new Camera camera;

    private Vector3 tempCenter, targetDirection, tempMousePos;
    private float tempSens;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        UpdateInput();
        UpdatePosition();
    }

    private void UpdateInput()
    {
        Vector2 mousePosition = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.Mouse2)) 
            OnPointDown(new Vector3(mousePosition.x * sensitivityX, 0, mousePosition.y * sensitivityY));
        else if (Input.GetKeyUp(KeyCode.Mouse2)) 
            OnPointUp();
        else if (Input.GetKey(KeyCode.Mouse2)) 
            OnPointMove(new Vector3(mousePosition.x * sensitivityX, 0, mousePosition.y * sensitivityY));
    }

    private void UpdatePosition()
    {
        float speed = Time.deltaTime * this.moveSpeed;
        if (this.isDragging) this.tempSens = this.sensitivity;
        else this.tempSens = Mathf.Lerp(this.tempSens, 0f, speed);
        Vector3 newPosition = transform.position + this.targetDirection * this.tempSens;
        transform.position = Vector3.Lerp(transform.position, newPosition, speed);
    }

    private void OnPointDown(Vector3 mousePosition)
    {
        this.tempCenter = GetWorldPoint(mousePosition);
        this.targetDirection = Vector3.zero;
        this.tempMousePos = mousePosition;
        this.isDragging = true;
    }

    private void OnPointMove(Vector3 mousePosition)
    {
        if (this.isDragging)
        {
            Vector3 point = GetWorldPoint(mousePosition);
            float sqrDist = (this.tempCenter - point).sqrMagnitude;
            if (sqrDist > 0.1f)
            {
                this.targetDirection = (this.tempMousePos - mousePosition).normalized;
                this.tempMousePos = mousePosition;
            }
        }
    }

    private void OnPointUp()
    {
        this.isDragging = false;
    }

    private Vector3 GetWorldPoint(Vector3 mousePosition)
    {
        Vector3 point = Vector3.zero;
        Ray ray = this.camera.ScreenPointToRay(mousePosition);
        Vector3 normal = Vector3.down;
        Vector3 position = Vector3.zero;
        Plane plane = new Plane(normal, position);
        float distance;
        plane.Raycast(ray, out distance);
        point = ray.GetPoint(distance);
        return point;
    }
}