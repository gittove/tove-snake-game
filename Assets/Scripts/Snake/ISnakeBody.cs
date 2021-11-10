using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISnakeBody<T>
{
    public void Add(T item);

    public void Clear();

    public T this[int index] { get; set; }
}
