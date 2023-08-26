/*         INFINITY CODE         */
/*   https://infinity-code.com   */

using UnityEngine;

namespace InfinityCode.OnlineMapsExamples
{
    /// <summary>
    /// Пример изменения масштаба маркеров при изменении зума.
    /// </summary>
    [AddComponentMenu("Infinity Code/Online Maps/Examples (API Usage)/MarkerScaleByZoomExample")]
    public class MarkerScaleByZoomExample : MonoBehaviour
    {
        /// <summary>
        /// Zoom, когда масштаб равен 1.
        /// </summary>
        public int defaultZoom = 15;

        /// <summary>
        /// Экземпляр маркера.
        /// </summary>
        private OnlineMapsMarkerBase marker;

        /// <summary>
        /// Инициализация.
        /// </summary>
        public void Go()
        {
            // Создание нового маркера.
            marker = OnlineMapsMarkerManager.CreateItem(Vector2.zero);

            // Подписка на изменение зума.
            OnlineMaps.instance.OnChangeZoom += OnChangeZoom;

            // Инициальное изменение масштаба маркера.
            OnChangeZoom();
        }

        /// <summary>
        /// При изменении зума.
        /// </summary>
        private void OnChangeZoom()
        {
            float originalScale = 1 << defaultZoom;
            float currentScale = 1 << OnlineMaps.instance.zoom;

            // Получение текущих GPS-координат
          

            // Преобразование GPS-координат в мировые координаты
     

            // Установка мировых координат маркера
            marker.SetPosition(51.115702, 71.422937);

            // Изменение масштаба маркера на основе зума
            marker.scale = currentScale / originalScale;
        }

        // TODO: Добавьте ваш код для получения текущих GPS-координат (latitude, longitude)
        // инициализации GPS и обновления координат в методе OnChangeZoom()
    }
}