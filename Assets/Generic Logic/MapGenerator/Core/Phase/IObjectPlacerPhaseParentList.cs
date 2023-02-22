using UnityEngine;
using System.Collections.Generic;

namespace MapGeneration.DungeonGenerator
{
	public partial class ObjectsPlacerPhase
	{
		public interface IObjectPlacerPhaseParentList
		{
			List<Transform> Parents { get; }
		}
	}
}