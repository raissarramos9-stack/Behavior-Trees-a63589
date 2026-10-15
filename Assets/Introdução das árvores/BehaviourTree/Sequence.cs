using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    public Sequence(string n)
    {
        name = n;
    }

    public override Status Process()
    {
    Status childstatus = children[currentChild].Process();
    if (childstatus == Status.RUNNING) return Status.RUNNING;
    if (childstatus == Status.FAILURE)
    return childstatus;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
