using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>CameraFollowLevel2</c> makes sure the camera is locked onto the layer at all times.
/// </summary>
public class CameraFollowLevel2 : MonoBehaviour
{
    /// <summary>
    /// A refference to the camera's Unity transform object
    /// </summary>
    private Transform target;
    /// <summary>
    /// The x coordinate of the minimal map point
    /// </summary>
    private float xMin;
    /// <summary>
    /// The x coordinate of the maximal map point
    /// </summary>
    private float xMax;
    /// <summary>
    /// The y coordinate of the minimal map point
    /// </summary>
    private float yMin;
    /// <summary>
    /// The y coordinate of the maximal map point
    /// </summary>
    private float yMax;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        target = Player.GetInstance().transform;

        GameObject sprite2 = GameObject.FindGameObjectWithTag("Limit down");
        Vector3 minTile = sprite2.GetComponent<SpriteRenderer>().bounds.min;

        GameObject sprite = GameObject.FindGameObjectWithTag("Limit up");
        Vector3 maxTile = sprite.GetComponent<SpriteRenderer>().bounds.max;

        SetLimits(minTile, maxTile);
    }

    /// <summary>
    /// LateUpdate is called once per frame.
    /// </summary>
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);
    }

    /// <summary>
    /// Sets the camera's boundaries.
    /// </summary>
    /// <param name="minTile">The minimal tile of the map</param>
    /// <param name="maxTile">The maximal tile of the map</param>
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
