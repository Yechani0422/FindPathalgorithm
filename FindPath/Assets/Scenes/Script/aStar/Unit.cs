using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{


	[SerializeField]
	public Transform _agent = null;

	[SerializeField]
	public Transform _Target = null;

	private Vector3 _pickPos = Vector3.zero;

	[SerializeField]
	private float _maxSpeed = 1.0f;

	[SerializeField]
	private float _mass = 1.0f;

	[SerializeField]
	private float _deceleration = 1.0f;

	public Vector3 _velocity = Vector3.zero;

	public GridNode startNode;

	private Astar findPath;


	void Start()
	{
		findPath = GameObject.FindGameObjectWithTag("A*").GetComponent<Astar>();
	}

	void Update()
    {
		if (Input.GetMouseButtonUp(0))
		{
			Vector3 mouse_pos = Input.mousePosition;

			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mouse_pos), -Vector3.up, out hit, 1000))
			{
				_pickPos = hit.point;

				_Target.transform.position = _pickPos;
			}
		}


		if (findPath.UnitPath.Count != 0)
		{
			startNode = findPath.UnitPath.Peek();

			if (Vector3.Distance(_agent.transform.position, startNode.worldPosition) < 1.0f)
			{
				findPath.UnitPath.Pop();
			}

			_velocity = _velocity + ((seek(startNode.worldPosition) ) * Time.deltaTime);

			_agent.transform.position = _agent.transform.position + _velocity;

			_agent.transform.forward = _velocity.normalized;

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
