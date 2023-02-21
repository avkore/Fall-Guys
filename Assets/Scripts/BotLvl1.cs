using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class BotLvl1 : MonoBehaviour
{
    [SerializeField] private Gamemanager gameManager;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Transform> pinkGates;
    [SerializeField] private List<Transform> yellowGates;
    [SerializeField] private List<Transform> greenGates;
    [SerializeField] private List<Transform> blueGates1;
    [SerializeField] private List<Transform> blueGates2;
    [SerializeField] private Transform finishGate;

    private List<List<Transform>> gatesList = new List<List<Transform>>();


    private bool generated;
    private Animator anim;
    private bool hasPassed;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        gatesList.Add(pinkGates);
        gatesList.Add(yellowGates);
        gatesList.Add(greenGates);
        gatesList.Add(blueGates1);
        gatesList.Add(blueGates2);

        //Start Coroutine
        StartCoroutine(StartLoop());
    }

    void Update()
    {
        if (gameManager.hasStarted)
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !generated)
        {
            anim.SetInteger("AnimationIndex", Random.Range(1, 8));
            anim.SetTrigger("RandomAnimation");
            generated = true;
        }
    }

    private IEnumerator StartLoop()
    {
        yield return new WaitUntil(() => gameManager.hasStarted);

        StartCoroutine(ChooseDoorFromList(0));
    }

    private IEnumerator ChooseDoorFromList(int i)
    {
        int RandomDoorIndex = Random.Range(0, gatesList[i].Count);
        var target = gatesList[i][RandomDoorIndex];
        agent.SetDestination(target.position);
        
        yield return new WaitUntil(() => Vector3.Distance(transform.position, target.position) <= 15f);

        if (target.GetComponent<Collider>().isTrigger)
        {
            i++;
            StartCoroutine(ChooseDoorFromList(i));
        }
        else
        {
            gatesList[i].Remove(gatesList[i][RandomDoorIndex]);
            Vector3 currentPos = agent.transform.position;
            Vector3 backPos = currentPos - agent.transform.forward * 5;
            agent.SetDestination(backPos);

            yield return new WaitUntil(() => Vector3.Distance(agent.transform.position, backPos) <= 3f);
            StartCoroutine(ChooseDoorFromList(i));
        }
        if(i == 5)
        {
            GoToFinishGate();
            yield break;
        }
    }

    private IEnumerator GoToFinishGate()
    {
        agent.SetDestination(finishGate.position);
        yield return new WaitUntil(() => Vector3.Distance(transform.position, finishGate.position) <= 5f);
    }
    
}


