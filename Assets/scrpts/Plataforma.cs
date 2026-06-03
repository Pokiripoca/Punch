using UnityEngine;

public class CarouselPlatform : MonoBehaviour
{
    [Header("Configuración del carrusel")]
    public Transform centerPoint;   // Centro del círculo
    public float radius = 3f;       // Radio del círculo
    public float speed = 50f;       // Velocidad angular en grados por segundo
    public float initialAngle = 0f; // Ángulo inicial único para cada plataforma

    private float angle;

    void Start()
    {
        // Cada plataforma arranca en un ángulo distinto
        angle = initialAngle;
    }

    void Update()
    {
        // Avanzar el ángulo constantemente
        angle += speed * Time.deltaTime;

        // Convertir ángulo a radianes
        float rad = angle * Mathf.Deg2Rad;

        // Calcular nueva posición en círculo
        float x = centerPoint.position.x + Mathf.Cos(rad) * radius;
        float y = centerPoint.position.y + Mathf.Sin(rad) * radius;

        transform.position = new Vector2(x, y);
    }
}