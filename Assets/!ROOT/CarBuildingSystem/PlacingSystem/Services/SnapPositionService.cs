using UnityEngine;

namespace _ROOT.CarBuildingSystem.PlacingSystem.Services
{
    public abstract class SnapPositionService
    {
        private const float GRID_SIZE = .01F;
        
        public static Vector3 Snap(RaycastHit hit, Transform tr)
        {
            var trCollider = tr.GetComponent<Collider>();
            if (trCollider == null)
                return Vector3.zero;

            // Находим крайнюю точку коллайдера в направлении нормали поверхности
            var farthestPoint = GetFarthestPointInDirection(trCollider, hit.normal);

            // Расстояние от центра объекта до его границы в направлении нормали
            var radiusFromCenterToFarthestPoint = Vector3.Distance(tr.position, farthestPoint);

            // Вычисляем новую позицию объекта
            var newPosition = hit.point + hit.normal * radiusFromCenterToFarthestPoint;

            // Округляем позицию до ближайшей точки сетки
            var gridPosition = new Vector3(
                Mathf.Round(newPosition.x / GRID_SIZE) * GRID_SIZE,
                Mathf.Round(newPosition.y / GRID_SIZE) * GRID_SIZE,
                Mathf.Round(newPosition.z / GRID_SIZE) * GRID_SIZE
            );
            
            DebugDrawFarthestPoint(tr.position, farthestPoint, hit.normal, hit.point);

            return gridPosition;
        }
        
        /// <summary>
        /// Находит крайнюю точку коллайдера в заданном направлении.
        /// </summary>
        /// <param name="collider">Коллайдер объекта.</param>
        /// <param name="direction">Направление (нормализованный вектор).</param>
        /// <returns>Крайняя точка коллайдера в заданном направлении.</returns>
        private static Vector3 GetFarthestPointInDirection(Collider collider, Vector3 direction)
        {
            if (collider == null)
            {
                Debug.LogError("Collider is null!");
                return Vector3.zero;
            }

            // Получаем границы коллайдера
            var bounds = collider.bounds;

            // Нормализуем направление (на всякий случай)
            direction.Normalize();

            // Вычисляем крайнюю точку
            var farthestPoint = bounds.center;

            // Проецируем направление на оси границ коллайдера
            farthestPoint.x += direction.x * bounds.extents.x;
            farthestPoint.y += direction.y * bounds.extents.y;
            farthestPoint.z += direction.z * bounds.extents.z;

            return farthestPoint;
        }
        
        private static void DebugDrawFarthestPoint(Vector3 objectCenter, Vector3 farthestPoint, Vector3 direction, Vector3 hitPoint)
        {
            // Рисуем линию от центра объекта до farthestPoint
            Debug.DrawLine(objectCenter, farthestPoint, Color.green, .1f);

            // Рисуем сферу в farthestPoint
            DebugDrawSphere(farthestPoint, 0.1f, Color.green, .1f);

            // Рисуем направление от центра объекта к hit.point
            if (Camera.main != null)
            {
                var cameraPos = Camera.main.transform.position;
                Debug.DrawRay(cameraPos, direction * Vector3.Distance(cameraPos, hitPoint), Color.blue, .1f);
            }

            // Рисуем точку попадания (hit.point)
            DebugDrawSphere(hitPoint, 0.1f, Color.red, .1f);
        }

        /// <summary>
        /// Рисует сферу в заданной позиции.
        /// </summary>
        private static void DebugDrawSphere(Vector3 position, float radius, Color color, float duration)
        {
            // Рисуем 3 перпендикулярных круга, чтобы создать эффект сферы
            Debug.DrawLine(position - Vector3.up * radius, position + Vector3.up * radius, color, duration);
            Debug.DrawLine(position - Vector3.right * radius, position + Vector3.right * radius, color, duration);
            Debug.DrawLine(position - Vector3.forward * radius, position + Vector3.forward * radius, color, duration);
        }
    }
}