using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFabricMethod<T> where T : MonoBehaviour
{
    T CreateNew(T prefab, Vector3 position, Quaternion rotation);
}
