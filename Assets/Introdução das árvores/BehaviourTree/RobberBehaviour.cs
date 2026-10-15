using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : MonoBehaviour
{
    BehaviourTree tree;
    public GameObject diamond;
    public GameObject van;
    NavMeshAgent agent;

    Node.Status treeStatus = Node.Status.RUNNING;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        tree = new BehaviourTree();
        Sequence steal = new Sequence("Steal Something");
        Leaf goToDiamond = new Leaf ("Go To Diamond", GoToDiamond);
        Leaf goToBackDoor = new Leaf("Go To Backdoor", GoToBackDoor);
        Leaf goToVan = new Leaf("Go To Van", GoToVan);

        steal.AddChild(goToBackDoor);
        steal.AddChild(goToDiamond);
        steal.AddChild(goToBackDoor);
        steal.AddChild(goToVan);
        tree.AddChild(steal);


        tree.PrintTree();

        
    }

    public Node.Status GoToDiamond()
    {
         agent.SetDestination(diamond.transform.position);
         return Node.Status.SUCESS;
    }

    public Node.Status GoToVan()
    {
         agent.SetDestination(diamond.transform.position);
         return Node.Status.SUCESS;
    }

    }
    Node.Status GoToLocation(Vector3 destination)
    {
        float distanceTotarget = Vector3(destination, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PrintTree()
    {
        string treePrintout = "";
        Stack<Node> nodeStack = new Stack<Node>();
        Node currentNode = this;
        nodeStack.Push(currentNode);

        while (nodeStack.Count != 0)
        {
          Node nextNode = nodeStack.Pop();
          treePrintout += nextNode.name + "\n";
          for(int i = nextNode.children.Count -1; i>= 0; i--)
          {
            nodeStack.Push(nextNode.children[i]);
          }
        }
        Debug.Log(treePrintout);
    }
}
