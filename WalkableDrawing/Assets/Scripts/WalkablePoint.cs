using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D), typeof(LineRenderer))]
public class WalkablePoint : MonoBehaviour
{
    LineRenderer lineRenderer;
    EdgeCollider2D edgeCollider;
    List<Vector2> collisionPoints = new List<Vector2>();

    private void Start()
    {
        collisionPoints = new List<Vector2>();

        collisionPoints.Add(transform.InverseTransformPoint(transform.position));
        collisionPoints.Add(transform.InverseTransformPoint(new Vector3(transform.position.x + 0.01f, transform.position.y, 0)));

        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
        edgeCollider.points = collisionPoints.ToArray();
    }



    public void AddNewCollisionPoint(Vector2 position)
    {

        if (collisionPoints.Count > 0 && collisionPoints[collisionPoints.Count - 1] == position)
        {
            Debug.Log("same pos as before");
            return;
        }
        collisionPoints.Add(transform.InverseTransformPoint(position));
        lineRenderer.positionCount = collisionPoints.Count;

        edgeCollider.points = collisionPoints.ToArray();
        lineRenderer.SetPosition(collisionPoints.Count - 1, position);
    }
}
