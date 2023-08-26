using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomToCoordinates : MonoBehaviour
{
     public double targetLatitude = 51.115702;
    public double targetLongitude = 71.422937;
    public int zoomLevel = 15;
    public float zoomSpeed = 5f;

    private bool isZooming = false;

    private void Start()
    {
        // Зумирование к указанным координатам при запуске
        OnlineMaps.instance.position = new Vector2((float)targetLongitude, (float)targetLatitude);
        OnlineMaps.instance.zoom = zoomLevel;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Запуск процесса плавного зумирования к указанным координатам при нажатии клавиши "Пробел"
            ZoomToTargetLocation();
        }

        if (isZooming)
        {
            // Плавное зумирование к указанным координатам
            ZoomInToTargetLocation();
        }
    }

    private void ZoomToTargetLocation()
    {
        // Запуск процесса плавного зумирования к указанным координатам

        isZooming = true;
    }

    private void ZoomInToTargetLocation()
    {
        // Плавное зумирование к указанным координатам

        // Определение текущей позиции и масштаба карты
        Vector2 currentPosition = OnlineMaps.instance.position;
        int currentZoom = OnlineMaps.instance.zoom;

        // Проверка, достигнут ли нужный уровень масштаба
        if (currentZoom == zoomLevel)
        {
            isZooming = false; // Завершение процесса зумирования
            return;
        }

        // Интерполяция между текущей позицией и целевой позицией
        float t = Time.deltaTime * zoomSpeed;
        Vector2 newPosition = Vector2.Lerp(currentPosition, new Vector2((float)targetLongitude, (float)targetLatitude), t);
        int newZoom = Mathf.RoundToInt(Mathf.Lerp(currentZoom, zoomLevel, t));

        // Установка новой позиции и масштаба карты
        OnlineMaps.instance.position = newPosition;
        OnlineMaps.instance.zoom = newZoom;
    }
}