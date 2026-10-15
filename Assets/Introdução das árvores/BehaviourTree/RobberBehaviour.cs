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

    public enum ActionState { IDLE, WORKING }
    ActionState state = ActionState.IDLE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        tree = new BehaviourTree();
        Node steal = new Node("Steal Something");
        Node goToDiamond = new Leaf ("Go To Diamond");
        Node goToVan = new Leaf ("Go To Van");

        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);


        tree.PrintTree();

        tree.Process();
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
}
