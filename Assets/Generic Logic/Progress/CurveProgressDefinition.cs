using UnityEngine;

namespace Progress
{
	[CreateAssetMenu(fileName = "CurveProgressDefinition", menuName = "Progress/CurveProgressDefinition")]
	public class CurveProgressDefinition : ProgressDefinition
	{
		[SerializeField] private AnimationCurve m_levelCurve = new AnimationCurve();
		public override int Evaluate(float experience, int currentLevel)
		{
			throw new System.NotImplementedException();
		}
	}
}
