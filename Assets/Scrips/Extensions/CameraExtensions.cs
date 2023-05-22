namespace ZombieTestProject.Extensions
{
    using UnityEngine;
    public static class CameraExtensions
    {
        public static Vector2 GetRandomPosition (this Camera camera, float offset) 
        {

        float cameraHeight = 2f * camera.orthographicSize;

        float cameraWidth = cameraHeight * camera.aspect;

        Vector2 cameraBoundsMax = new Vector2(camera.transform.position.x + cameraWidth / 2f, camera.transform.position.y + cameraHeight / 2f);

       float x = Random.Range(-cameraBoundsMax.x, cameraBoundsMax.x) - Random.Range(-offset, offset);

       float y = Random.Range(-cameraBoundsMax.y, cameraBoundsMax.y) - Random.Range(-offset, offset);

       return new Vector2(x, y);
        }
    }
}