using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeList<T>
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
        public Sprite nodeSprite;
        public Vector3 nodePosition;

        public SnakeNode(GameObject item, SnakeNode node, int i)
        {
            nodeItem = item;
            nextNode = node;
            index = i;
            nodeSprite = nodeItem.GetComponent<Sprite>();
            nodePosition = nodeItem.transform.position;
        }
    }

    public Transform GetTailTransform => _tail.nodeItem.transform;

    public int Count { get => _count; }

    public void CreateBody(GameObject headItem, GameObject tailItem)
    {
        _head = new SnakeNode(headItem, null, _count);
        _count++;

        _tail = _head;
        _tail.nextNode = new SnakeNode(tailItem, null, _count);
        _tail = _tail.nextNode;
        _count++;
    }

    public void Insert(GameObject item, int index)
    {
        SnakeNode currentNode = _head;
        SnakeNode previousNode = _head;

        for (int i = 0; i < index; i++)
        {
            previousNode = currentNode;
            currentNode = currentNode.nextNode;
        }

        SnakeNode newNode = new SnakeNode(item, currentNode, index);
        previousNode.nextNode = newNode;
        UpdateIndeces(newNode);
        _count++;
    }

    public void Add(GameObject item)
    {
        _tail.nextNode = new SnakeNode(item, null, _count);
        _tail = _tail.nextNode;
        UpdateIndeces(_tail);
    }

    private void UpdateIndeces(SnakeNode node)
    {
        while (node != null)
        {
            node.index++;
            node = node.nextNode;
        }
    }

    private SnakeNode GetTail()
    {
        SnakeNode currentNode = _head;
        while(currentNode.nextNode.nextNode != null)
        {
            currentNode = currentNode.nextNode;
        }
        _tail = currentNode;
        _tail.nextNode = null;
        return _tail;
    }

    public void MoveNodes(Transform previousHeadTransform)
    {
        _tail.nodeItem.transform.position = previousHeadTransform.position;
        _tail.nodeItem.transform.rotation = previousHeadTransform.rotation;
        Insert(_tail.nodeItem, 1);
        _tail = GetTail();
    }

    public void Clear()
    {
        _count = 0;
        _head = null;
        _tail = null;
    }

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
