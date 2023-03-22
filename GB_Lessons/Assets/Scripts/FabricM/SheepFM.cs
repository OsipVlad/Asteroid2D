using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepFM<T> : IFabricMethod<T> where T : MonoBehaviour
{
    Transform container;
    public SheepFM(Transform container) => this.container = container;
    public SheepFM() => container = null;

    public T Create(T prefab, Vector3 position, Quaternion rotation) => GameObject.Instantiate(prefab, position, rotation, container);

    public T CreateNew(T prefab, Vector3 position, Quaternion rotation) => Create(prefab, position, rotation);

}
