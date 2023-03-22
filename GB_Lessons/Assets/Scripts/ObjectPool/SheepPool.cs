using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class SheepPool<T> : IObjectPool<T> where T : MonoBehaviour
{
    T prefab;
    IFabricMethod<T> factory;
    Transform container;

    bool isExpend;
    List<T> pool;

    public SheepPool(T prefab, int count, bool isExpend, Transform container, IFabricMethod<T> factory)
    {

        pool = new List<T>();
        this.prefab = prefab;
        this.isExpend = isExpend;
        this.container = container;
        this.factory = factory;
        CreatePool(count);

    }
    public SheepPool(T prefab, int count, Transform container, IFabricMethod<T> factory)
    {

        pool = new List<T>();
        this.container = container;
        this.prefab = prefab;
        this.factory = factory;
        CreatePool(count);
    }
    public SheepPool(T prefab, int count, IFabricMethod<T> factory)
    {

        pool = new List<T>();
        this.container = null;
        this.prefab = prefab;
        this.factory = factory;
        CreatePool(count);
    }
    private void CreatePool(int count)
    {

        for (int i = 0; i < count; i++)
            CreateObject(container.position, container.rotation);
    }

    public T CreateObject(Vector3 position, Quaternion rotation, bool isActive = false)
    {

        var element = factory.CreateNew(prefab, position, rotation);
        pool.Add(element);
        element?.gameObject.SetActive(isActive);
        return element;
    }
    private bool HasFreeObjectInPool(out T element, Vector3 position, Quaternion rotation)
    {

        foreach (var mono in pool)
        {

            if (!mono.isActiveAndEnabled)
            {

                element = mono;
                mono.gameObject.SetActive(true);
                mono.transform.position = position;
                mono.transform.rotation = rotation;
                return true;
            }
        }
        element = null;
        return false;
    }
    public T GetFreeObject(Vector3 position, Quaternion rotation)
    {

        if (HasFreeObjectInPool(out T element, position, rotation))
            return element;
        if (isExpend)
            return CreateObject(position, rotation, true);

        return null;
        // throw new Exception("Ошибка создания объекта в пулле, объект не свободен");
    }
    public void ReturnObject(T obj)
    {

        foreach (var mono in pool)
            if (mono == obj) mono.gameObject.SetActive(false);
    }
}
