using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities.States;


public class SwathStateConditionInjector : MonoBehaviour, ISwitchStateCondition
{
	[SerializeField] private SwitchStateStateLogicReferenceHost[] m_destinationSwitchStateStateLogicReferenceHosts = null;
	[SerializeField] private Object[] m_objects = null;
	[SerializeField] private SwitchStateStateLogic.ConditionMode _mode = SwitchStateStateLogic.ConditionMode.All;

	private IEnumerable<SwitchStateStateLogic> m_destinationSwitchStateLogic = null;
	private IEnumerable<ISwitchStateCondition> m_conditions = null;

	public bool Condition
	{
		get
		{
			var isEmpty = m_conditions.Count() == 0;
			if (isEmpty) return false;
			return _mode switch
			{
				SwitchStateStateLogic.ConditionMode.All => m_conditions.All(condition => condition.Condition),
				SwitchStateStateLogic.ConditionMode.Any => m_conditions.Any(condition => condition.Condition),
				_ => false
			};
		}
	}

	private void Awake()
	{
		m_conditions = m_objects.OfType<ISwitchStateCondition>();
		m_destinationSwitchStateLogic = m_destinationSwitchStateStateLogicReferenceHosts
			.Where(host => host.Instance != null)
			.Select(host => host.Instance);
	}

	private void Start()
	{
		InjectConditions();
	}

	private void InjectConditions()
	{
		foreach (var switchStateLogic in m_destinationSwitchStateLogic)
			switchStateLogic.AddCondition(this);
	}

	private void OnDestroy()
	{
		foreach (var switchStateLogic in m_destinationSwitchStateLogic)
				switchStateLogic.RemoveCondition(this);
	}
}
