using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform[] _movePostionTransform;
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _characterController;

    private NavMeshAgent navMeshAgent;
    private Vector3 _point;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator= GetComponent<Animator>();
        _characterController= GetComponent<CharacterController>();


        //StartCoroutine(MovePoint());
    }

    private void Update()
    {
        navMeshAgent.destination = _point;

        Debug.Log(navMeshAgent.hasPath);

        if(navMeshAgent.hasPath == false)
        {
            StartCoroutine(MovePoint());
        }


        if (navMeshAgent.velocity.magnitude > 0.1)
        {
            _animator.SetBool("Walk", true);
            //Debug.Log("Move");
        }
        else
        {
            _animator.SetBool("Walk", false);
            //Debug.Log("Done!");
        }
    }


    IEnumerator MovePoint()
    {
        
        _point = _movePostionTransform[Random.Range(0, 3)].position;

        yield return new WaitForSeconds(Random.Range(3, 7));
    }
}
