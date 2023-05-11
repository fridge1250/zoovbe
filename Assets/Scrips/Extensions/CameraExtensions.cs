namespace ZombieTestProject.Extensions
{
    using UnityEngine;
    public static class CameraExtensions
    {
        public static Vector2 GetRandomPosition (this Camera camera) 
        {

        float cameraHeight = 2f * camera.orthographicSize;

        float cameraWidth = cameraHeight * camera.aspect;

        Vector2 cameraBoundsMax = new Vector2(camera.transform.position.x + cameraWidth / 2f, camera.transform.position.y + cameraHeight / 2f);

       float x = Random.Range(-cameraBoundsMax.x, cameraBoundsMax.x);

       float y = Random.Range(-cameraBoundsMax.y, cameraBoundsMax.y);

       return new Vector2(x, y);
        }
    }
}