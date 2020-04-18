using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputReceiver : MonoBehaviour
{
    public WalkablePoint walkablePointPrefab;

    bool startUpdatingCollisionPoint;
    Camera mainCam;

    WalkablePoint currentUpdatableLine;
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (startUpdatingCollisionPoint)
        {
            UpdateCollisionPointForLine();
        }

        if (Input.GetMouseButtonDown(0))
        {
            startUpdatingCollisionPoint = true;
            InitializeLine();
        }

        if (Input.GetMouseButtonUp(0))
        {
            startUpdatingCollisionPoint = false;
        }

    }


    void InitializeLine()
    {
        currentUpdatableLine = Instantiate(walkablePointPrefab, getMouseToWorldPos(), Quaternion.identity) as WalkablePoint;
    }
    void UpdateCollisionPointForLine()
    {
        currentUpdatableLine.AddNewCollisionPoint(getMouseToWorldPos());
    }

    Vector3 getMouseToWorldPos()
    {
        return mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
