using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeList<T>
{
    private Sprite _bodypartSprite;
    private Sprite _tailSprite;
    private SnakeNode _head;
    private SnakeNode _tail;
    private int _count;
    private HashSet<Vector3> _bodyPositions = new HashSet<Vector3>();

    public SnakeList(Sprite bodyPartSprite, Sprite tailSprite)
    {
        _bodypartSprite = bodyPartSprite;
        _tailSprite = tailSprite;
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
            nodePosition = nodeItem.transform.position;
        }
    }

    public Transform GetTailTransform => _tail.nodeItem.transform;

    public void CreateBody(GameObject headItem, GameObject tailItem)
    {
        _bodyPositions.Add(headItem.transform.position);
        _bodyPositions.Add(tailItem.transform.position);

        _head = new SnakeNode(headItem, null, _count);
        _count++;

        _tail = _head;
        _tail.nextNode = new SnakeNode(tailItem, null, _count);
        _tail = _tail.nextNode;
        _count++;
    }

    public void Insert(GameObject newItem, int itemIndex)
    {
        SnakeNode currentNode = _head;
        SnakeNode previousNode = _head;

        for (int i = 0; i < itemIndex; i++)
        {
            previousNode = currentNode;
            currentNode = currentNode.nextNode;
        }

        SnakeNode newNode = new SnakeNode(newItem, currentNode, itemIndex);
        previousNode.nextNode = newNode;
        UpdateIndeces(newNode);
        _count++;
    }

    public void Add(GameObject item)
    {
        _bodyPositions.Add(item.transform.position);
        _tail.nextNode = new SnakeNode(item, null, _count);
        _tail = _tail.nextNode;
        UpdateIndeces(_tail);
    }

    private void UpdateIndeces(SnakeNode startNode)
    {
        SnakeNode currentNode = startNode;

        while (currentNode != null)
        {
            currentNode.index++;
            currentNode = currentNode.nextNode;
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

    public bool CheckForCollision(Vector3 nextHeadPosition)
    {
        if(_bodyPositions.Contains(nextHeadPosition))
        {
            return true;
        }

        return false;
    }

    public void MoveNodes(Transform previousHeadTransform, Vector3 nextHeadPosition)
    {
        SpriteRenderer newTailRenderer;
        SpriteRenderer tailRenderer = _tail.nodeItem.GetComponent<SpriteRenderer>();

        _bodyPositions.Remove(_tail.nodePosition);
        _bodyPositions.Add(nextHeadPosition);

        _tail.nodeItem.transform.position = previousHeadTransform.position;
        _tail.nodeItem.transform.rotation = previousHeadTransform.rotation;
        tailRenderer.sprite = _bodypartSprite;

        Insert(_tail.nodeItem, 1);
        _tail = GetTail();

        newTailRenderer = _tail.nodeItem.GetComponent<SpriteRenderer>();
        newTailRenderer.sprite = _tailSprite;
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
