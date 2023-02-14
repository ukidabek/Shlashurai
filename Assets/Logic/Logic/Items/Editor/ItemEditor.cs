using UnityEditor;

namespace Shlashurai.Items
{
	[CustomEditor(typeof(Item))]
	public class ItemEditor : Editor
	{
		protected override void OnHeaderGUI()
		{
			base.OnHeaderGUI();
		}
	}
}