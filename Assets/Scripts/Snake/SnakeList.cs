using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeList<GameObject> : ISnakeBody<GameObject>
{
    private SnakeNode _head;
    private SnakeNode _tail;
    private int _count;


    public SnakeList()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    private class SnakeNode
    {
        public GameObject nodeItem;
        public SnakeNode nextNode;
        public int index = -1;
        public Vector2 nodePosition;

        public SnakeNode(GameObject item, SnakeNode node, int i, Vector2 position)
        {
            nodeItem = item;
            nextNode = node;
            index = i;
            nodePosition = position;
        }
    }

    // do we need this?
    public int Count { get => _count; }

    public void Add(GameObject item)
    {
        SnakeNode tailNode = _tail;
        SnakeNode node = new SnakeNode(item, null, _count, tailNode.nodePosition);

        if (_count == 0)
        {
            _head = node;
        }

        else
        {
            _tail.nextNode = node;
            _tail = node;
        }

        _count++;
    }

    public void Clear()
    {
        _count = 0;
        _head = null;
        _tail = null;
    }

    //do we need this?
    public GameObject this[int index] 
    {
        get
        {
            if (index >= _count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            SnakeNode currentNode = _head;
            while (currentNode != null)
            {
                if (index == currentNode.index)
                {
                    return currentNode.nodeItem;
                }
                currentNode = currentNode.nextNode;
            }
            throw new IndexOutOfRangeException();
        }
        set
        {
            if (index >= _count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            SnakeNode currentNode = _head;
            while (currentNode != null)
            {
                if (index == currentNode.index)
                {
                    currentNode.nodeItem = value;
                    return;
                }
                currentNode = currentNode.nextNode;
            }
            throw new IndexOutOfRangeException();
        }
    }
}
