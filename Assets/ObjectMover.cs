 using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [HideInInspector] public List<GameObject> points = new List<GameObject>();
    [SerializeField] public GameObject pointPrefab;
    [SerializeField] private float speed = 4.5f;

    GameObject point;

    public void CreatePoint()
    {
        Vector3 position = transform.position;

        // Pokud existuje poslední bod, použijte jeho pozici
        if (points.Count > 0)
        {
            position = points[points.Count - 1].transform.position;
        }

        point = Instantiate(pointPrefab, position, Quaternion.identity, this.transform);
        points.Add(point);
    }

    public void DestroyPoint()
    {
        DestroyImmediate(points.Last());
        points.RemoveAt(points.Count - 1);
    }
}
