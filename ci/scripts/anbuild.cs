using UnityEngine;

public class AngleCounter : MonoBehaviour
{
    /// <summary>
    /// Возвращает угол между двумя целями
    /// </summary>
    /// <param name="target"></param>
    /// <param name="start"></param>
    /// <returns></returns>
    static public float GetAngle(Transform target, Transform start)
    {
        Vector3 targetDir = target.position - start.position;
        Vector3 right = start.right;
        if (target.position.y<start.position.y)
        {
            return Vector3.SignedAngle(targetDir, right, Vector3.right)*-1;
        }
        return Vector3.SignedAngle(targetDir, right, Vector3.right);
    }
    static public float GetAngle(Vector3 target, Transform start)
    {
        Vector3 targetDir = target - start.position;
        Vector3 right = start.right;
        if (target.y < start.position.y)
        {
            return Vector3.SignedAngle(targetDir, right, Vector3.right) * -1;
        }
        return Vector3.SignedAngle(targetDir, right, Vector3.right);
    }
}