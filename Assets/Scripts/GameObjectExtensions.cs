using UnityEngine;

public static class GameObjectExtensions
{
    public static T Instantiate<T>(this T component) where T : MonoBehaviour
    {
        return Object.Instantiate(component.gameObject).GetComponent<T>();
    }

    public static T Instantiate<T>(this T component, Transform parent, bool worldPositionStays = true) where T : MonoBehaviour
    {
        T val = Instantiate(component);
        val.transform.SetParent(parent, worldPositionStays);
        val.transform.localPosition = Vector3.one;
        return val;
    }   
}
