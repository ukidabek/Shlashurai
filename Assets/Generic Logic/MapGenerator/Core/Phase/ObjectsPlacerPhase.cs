using UnityEngine;

using System.Collections;
using System.Collections.Generic;

using MapGeneration.BaseGenerator;
using System;

namespace MapGeneration.DungeonGenerator
{
	public partial class ObjectsPlacerPhase : GenerationPhase
	{
		[Serializable]
		public class ObjectPlacerPhaseConfiguration
		{
			[SerializeField] private int _phaseIndex = 0;
			public int PhaseIndex { get { return _phaseIndex; } }

			[SerializeField] private AmountToGenerate _amountToGenerate = new AmountToGenerate();
			public AmountToGenerate AmountToGenerate { get { return _amountToGenerate; } }

			[SerializeField] private List<GameObject> _prefabList = new List<GameObject>();
			public GameObject Prefab
			{
				get
				{
					float value = UnityEngine.Random.Range(0, 1f);
					if (value <= _probability)
						return _prefabList[UnityEngine.Random.Range(0, _prefabList.Count)];
					else
						return null;
				}
			}

			[SerializeField, Range(0f, 1f)] private float _probability = .5f;
		}

		public override IEnumerator Generate(LevelGenerator generator)
		{
			var config = generator.GetMetaDataObject<IObjectPlacerPhaseConfigurationProvider>()[generator.PhaseIndex];
			var parents = generator.GetMetaDataObject<IObjectPlacerPhaseParentList>().Parents;

			if (config != null && parents != null)
			{
				for (int i = 0; i < parents.Count; i++)
				{
					for (int j = 0; j < config.AmountToGenerate; j++)
					{
						var prefab = config.Prefab;
						if (prefab)
						{
							var instance = Instantiate(prefab);
							instance.transform.SetParent(parents[i]);
							instance.transform.localPosition = Vector3.zero;
							instance.transform.localRotation = Quaternion.identity;
						}

						yield return new PauseYield(generator);
					}
				}
				yield return new PauseYield(generator);
			}

			_isDone = true;
		}
	}
}