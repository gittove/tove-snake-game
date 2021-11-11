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
        public Vector3 nodePosition;

        public SnakeNode(GameObject item, SnakeNode node, int i)
        {
            nodeItem = item;
            nextNode = node;
            index = i;
            nodePosition = item.transform.position;
        }
    }

    public void CreateBody(GameObject headItem, GameObject tailItem)
    {
        _head = new SnakeNode(headItem, null, _count);
        _count++;

        _tail = _head;
        _tail.nextNode = new SnakeNode(tailItem, null, _count);
        _tail = _tail.nextNode;
        _count++;
    }

    public void InsertBodyPart(GameObject item)
    {
        SnakeNode insertIndex = _head.nextNode;
        SnakeNode newNode;

        newNode = new SnakeNode(item, _head.nextNode, insertIndex.index);
        _head.nextNode = newNode;
        IncreaseIndex(_head.nextNode.nextNode);
        _count++;
    }

    private void IncreaseIndex(SnakeNode node)
    {
        while (node != null)
        {
            node.index++;
            node = node.nextNode;
        }
    }

    public void MoveNodes(Transform headTransform)
    {
        _head.nodeItem.transform.position = headTransform.position;
        _head.nodeItem.transform.rotation = headTransform.rotation;
        SnakeNode currentNode = _head.nextNode;
        SnakeNode previousNode = _head;

        while (currentNode != null)
        {
            currentNode.nodeItem.transform.position = previousNode.nodeItem.transform.position;
            currentNode.nodeItem.transform.rotation = previousNode.nodeItem.transform.rotation;
            previousNode = currentNode;
            currentNode = currentNode.nextNode;
        }
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
