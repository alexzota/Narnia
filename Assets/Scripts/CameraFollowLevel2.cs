using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowLevel2 : MonoBehaviour
{
    private Transform target;
    private float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        GameObject sprite2 = GameObject.FindGameObjectWithTag("Limit down");
        Vector3 minTile = sprite2.GetComponent<SpriteRenderer>().bounds.min;

        GameObject sprite = GameObject.FindGameObjectWithTag("Limit up");
        Vector3 maxTile = sprite.GetComponent<SpriteRenderer>().bounds.max;

        SetLimits(minTile, maxTile);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);
    }

    private void SetLimits(Vector3 minTile, Vector3 maxTile)
    {
        Camera cam = Camera.main;

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;

        yMin = minTile.y + height / 2;
        yMax = maxTile.y - height / 2;
    }
}
