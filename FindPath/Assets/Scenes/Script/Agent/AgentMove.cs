using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMove : MonoBehaviour
{
    [SerializeField]
    private Transform _agent = null;

    private Vector3 _pickPos = Vector3.zero;

    [SerializeField]
    private float _maxSpeed = 1.0f;

    [SerializeField]
    private float _mass = 1.0f;

    [SerializeField]
    private float _deceleration = 1.0f;

    private Vector3 _velocity = Vector3.zero;

    private bool IsStart;

    public List<GameObject> FoundObjects;
    public GameObject startNode;
    public GameObject endNode;
    public float shortDis;

    private newdijkstra dijkstra;

    // Start is called before the first frame update
    void Start()
    {
        dijkstra = GameObject.FindGameObjectWithTag("Graph").GetComponent<newdijkstra>();

        //시작노드
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Node"));
        shortDis = Vector3.Distance(_agent.transform.position, FoundObjects[0].transform.position);

        startNode = FoundObjects[0]; // 첫번째를 먼저 

        foreach (GameObject found in FoundObjects)
        {
            float Distance = Vector3.Distance(_agent.transform.position, found.transform.position);

            if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
            {
                startNode = found;
                shortDis = Distance;
            }
        }
        Debug.Log(startNode.name);
        

        IsStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouse_pos = Input.mousePosition;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mouse_pos), -Vector3.up, out hit, 1000))
            {
                _pickPos = hit.point;
            }

            FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Node"));
            shortDis = Vector3.Distance(_agent.transform.position, FoundObjects[0].transform.position);

            startNode = FoundObjects[0]; // 첫번째를 먼저 

            foreach (GameObject found in FoundObjects)
            {
                float Distance = Vector3.Distance(_agent.transform.position, found.transform.position);

                if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
                {
                    startNode = found;
                    shortDis = Distance;
                }
            }
            Debug.Log(startNode.name);
            dijkstra.start = int.Parse(startNode.name);

            //끝노드
            shortDis = Vector3.Distance(_pickPos, FoundObjects[0].transform.position);

            endNode = FoundObjects[0]; // 첫번째를 먼저 

            foreach (GameObject found in FoundObjects)
            {
                float Distance = Vector3.Distance(_pickPos, found.transform.position);

                if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
                {
                    endNode = found;
                    shortDis = Distance;
                }
            }
            Debug.Log(endNode.name);

           
            dijkstra.end = int.Parse(endNode.name);

            dijkstra.check = false;
            IsStart = true;
        }

        if (IsStart == true)
        {
            if (dijkstra.S.Count != 0)
            {
                startNode = GameObject.Find(dijkstra.S.Peek().ToString());

                GameObject pathNode;
                pathNode = GameObject.Find(dijkstra.S.Peek().ToString());
                pathNode.GetComponent<MeshRenderer>().material.color = Color.red;

                if(Vector3.Distance(_agent.transform.position,startNode.transform.position)<1.0f)
                {
                    dijkstra.S.Pop();
                }

                _velocity = _velocity + ((seek(startNode.transform.position) + arrive(startNode.transform.position)) * Time.deltaTime);

                _agent.transform.position = _agent.transform.position + _velocity;

                _agent.transform.forward = _velocity.normalized;

            }
            else if (dijkstra.S.Count == 0)
            {
                _velocity = _velocity + ((seek(_pickPos) + arrive(_pickPos)) * Time.deltaTime);

                _agent.transform.position = _agent.transform.position + _velocity;

                _agent.transform.forward = _velocity.normalized;

                foreach (GameObject found in FoundObjects)
                {
                    found.GetComponent<MeshRenderer>().material.color = Color.blue;
                }
                

                if (Vector3.Distance(_agent.transform.position, _pickPos) < 1.0f)
                {
                    dijkstra.Reset();
                }
            }
            
        }
    }

    private Vector3 seek(Vector3 target_pos)
    {
        Vector3 desired_velocity = ((target_pos - _agent.transform.position).normalized) * _maxSpeed;

        // y축의 값이 있을 수 있으므로, 최초에 0으로 만들어 y축의 값을 사용하지 않도록 한다.
        desired_velocity.y = 0.0f;

        return (desired_velocity - _velocity);
    }

    private Vector3 arrive(Vector3 target_pos)
    {
        float distance = Vector3.Distance(_agent.transform.position, target_pos);

        if (distance > 0.0f)
        {
            float _speed = distance / (_deceleration * 0.3f);

            _speed = Mathf.Min(_speed, _maxSpeed);

            Vector3 desired_velocity = ((_agent.transform.position - target_pos).normalized) * (_speed / distance);

            desired_velocity.y = 0.0f;

            return (desired_velocity - _velocity);
        }

        return Vector3.zero;
    }
}
