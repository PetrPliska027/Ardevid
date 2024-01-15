using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMover : MonoBehaviour, IInteractable
{
    public List<GameObject> points;
    [SerializeField] public GameObject pointPrefab;
    [SerializeField] private float speed = 4.5f;

    GameObject point;

    public Modes mode;

    public enum Modes
    {
        Step,
        Forward,
        Cycle
    }

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

    private void Update()
    { 

    }

    public void Interact()
    {
        switch (mode)
        {
            case (Modes.Step):
                Debug.Log("Step");

                break;
            case (Modes.Forward):
                Debug.Log("Formward");
                ForwardMovement();
                break;
            case (Modes.Cycle):
                Debug.Log("Cycle");
                break;
        }
    }

    public void StepMovement()
    {

    }

    public void ForwardMovement()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(points[0].transform.position, points[1].transform.position, step);
    }

    public void CycleMovement()
    {

    }
}
