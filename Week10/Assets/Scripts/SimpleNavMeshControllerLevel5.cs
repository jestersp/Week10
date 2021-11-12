using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;   

public class SimpleNavMeshControllerLevel5 : MonoBehaviour
{
    [SerializeField] public NavMeshAgent _agent;
    [SerializeField] public Camera _camera;
    [SerializeField] public ThirdPersonCharacter character;
    // Start is called before the first frame update
    void Start()
    {           
        _camera = Camera.main;
        _agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
        if (_agent.remainingDistance > _agent.stoppingDistance)
        {
            character.Move(_agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);  
        }
    }
}
