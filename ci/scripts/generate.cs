using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallShooter : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _ballPrefab;

    [Header("Shooting force")]
    [SerializeField] private float _forceForward;
    [SerializeField] private float _forceLeftRight;

    private Vector3 targetVector;

    private Vector3 mousePosition;

    private void OnMouseUp()
    {
        targetVector = Camera.main.ScreenToWorldPoint(Input.mousePosition + transform.position);
        var target = Instantiate(_target , targetVector , Quaternion.identity);
        PushBall(targetVector);
        Destroy(target);
    }

    private void PushBall(Vector3 target)
    {
        var ball = Instantiate(_ballPrefab,transform.position, Quaternion.identity);
        var rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3((target.x-transform.parent.position.x) * _forceLeftRight, (target.y - transform.parent.position.y) * _forceLeftRight, _forceForward));
    }
}
