using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPool<T> where T : MonoBehaviour
{
    T GetFreeObject(Vector3 position, Quaternion rotation);
    void ReturnObject(T obj);
}
