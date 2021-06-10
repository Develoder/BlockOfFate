using System;
using UnityEngine;

[DisallowMultipleComponent, RequireComponent(typeof(Camera))]
// Класс управление камерой
public sealed class CameraMove : MonoBehaviour
{
    [Range(0, 10f)] public float moveSpeed = 2.8f;
    [Range(0f, 5f)] public float sensitivity = 4;
    [Range(0.01f, 2f)] public float sensitivityX = 0.9f;
    [Range(0.01f, 2f)] public float sensitivityY = 0.5f;

    [Header("Лимиты камеры")] 
    [SerializeField] private float leftLimit = 5;
    [SerializeField] private float rightLimit = -5;
    [SerializeField] private float upperLimit = 5;
    [SerializeField] private float bottomLimit = -5;

    private bool isDragging;
    private new Camera camera;

    private Vector3 tempCenter, targetDirection, tempMousePos;
    private float tempSens;
    private Vector3 nextPosition;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        UpdateInput();
        UpdatePosition();
    }

    // Обновление нажатия
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

    // Обнволение позиции камеры
    private void UpdatePosition()
    {
        float speed = Time.deltaTime * moveSpeed;
        if (isDragging) tempSens = sensitivity;
        else tempSens = Mathf.Lerp(tempSens, 0f, speed);
        Vector3 newPosition = transform.position + targetDirection * tempSens;
        nextPosition = Vector3.Lerp(transform.position, newPosition, speed);
        
        // Задание позиции камеры по лимитам
        transform.position = new Vector3(
            Mathf.Clamp(nextPosition.x, rightLimit, leftLimit),
            nextPosition.y,
            Mathf.Clamp(nextPosition.z, bottomLimit, upperLimit)
            );
    }

    // Считывание данных по нажатой мышке
    private void OnPointDown(Vector3 mousePosition)
    {
        tempCenter = GetWorldPoint(mousePosition);
        targetDirection = Vector3.zero;
        tempMousePos = mousePosition;
        isDragging = true;
    }

    // Перемещение камеры
    private void OnPointMove(Vector3 mousePosition)
    {
        if (isDragging)
        {
            Vector3 point = GetWorldPoint(mousePosition);
            float sqrDist = (tempCenter - point).sqrMagnitude;
            if (sqrDist > 0.1f)
            {
                targetDirection = (tempMousePos - mousePosition).normalized;
                tempMousePos = mousePosition;
            }
        }
    }

    // Нажатие на экран
    private void OnPointUp()
    {
        this.isDragging = false;
    }

    // Возварщает глобальную позицию
    private Vector3 GetWorldPoint(Vector3 mousePosition)
    {
        Vector3 point = Vector3.zero;
        Ray ray = camera.ScreenPointToRay(mousePosition);
        Vector3 normal = Vector3.down;
        Vector3 position = Vector3.zero;
        Plane plane = new Plane(normal, position);
        float distance;
        plane.Raycast(ray, out distance);
        point = ray.GetPoint(distance);
        return point;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector3(leftLimit, 0.1f, upperLimit), new Vector3(rightLimit, 0.1f, upperLimit));
        Gizmos.DrawLine(new Vector3(rightLimit, 0.1f, upperLimit), new Vector3(rightLimit, 0.1f, bottomLimit));
        Gizmos.DrawLine(new Vector3(rightLimit, 0.1f, bottomLimit), new Vector3(leftLimit, 0.1f, bottomLimit));
        Gizmos.DrawLine(new Vector3(leftLimit, 0.1f, bottomLimit), new Vector3(leftLimit, 0.1f, upperLimit));
    }
}