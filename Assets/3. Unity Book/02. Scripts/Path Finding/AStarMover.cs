using System.Collections.Generic;
using UnityEngine;

public class AStarMover : MonoBehaviour
{
    private Transform startPos, endPos;
    public Node startNode { get; set; }
    public Node destNode { get; set; }

    public List<Node> pathList = new List<Node>();

    public GameObject objStartCube, objEndCube;
    private float elapsedTime = 0f;
    public float intervalTime = 1f;

    void Start()
    {
        GetPath();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= intervalTime)
        {
            elapsedTime = 0f;
            GetPath();
        }
    }

    void GetPath()
    {
        startPos = objStartCube.transform;
        endPos = objEndCube.transform;

        int startIndex = GridManager.Instance.GetGridIndex(startPos.position);
        int startRow = GridManager.Instance.GetRow(startIndex);
        int startCol = GridManager.Instance.GetColumn(startIndex);
        startNode = GridManager.Instance.nodes[startRow, startCol];

        int destIndex = GridManager.Instance.GetGridIndex(endPos.position);
        int destRow = GridManager.Instance.GetRow(destIndex);
        int destCol = GridManager.Instance.GetColumn(destIndex);
        destNode = GridManager.Instance.nodes[destRow, destCol];

        pathList = AStar.FindPath(startNode, destNode);
    }

    void OnDrawGizmos()
    {
        if (pathList == null)
            return;

        if (pathList.Count > 0)
        {
            int index = 1;
            foreach (Node node in pathList)
            {
                if (index < pathList.Count)
                {
                    Node nextNode = pathList[index];
                    Debug.DrawLine(node.pos, nextNode.pos, Color.green);
                    index++;
                }
            }
        }
    }
}