using UnityEngine;

namespace Shlashurai.Player.Input
{
	[CreateAssetMenu(menuName = "Shlashurai/Input/InputValues", fileName = "InputValues")]
	public class InputValues : ScriptableObject
	{
		[SerializeField] private Vector2 move = Vector2.zero;
		public Vector2 Move
		{
			get => move;
			set => move = value;
		}

		[SerializeField] private Vector2 m_look = Vector2.zero;
		public Vector2 Look
		{
			get => m_look;
			set => m_look = value;
		}

		[SerializeField] private bool m_slash = false;
		public bool Slash
		{
			get => m_slash;
			set => m_slash = value;
		}

		[SerializeField] private bool m_attack = false;
		public bool Attack
		{
			get => m_attack;
			set => m_attack = value;
		}

		[SerializeField] private bool m_cast1 = false;
		public bool Cast1
		{
			get => m_cast1;
			set => m_cast1 = value;
		}

		[SerializeField] private bool m_cast2 = false;
		public bool Cast2
		{
			get => m_cast2;
			set => m_cast2 = value;
		}

		[SerializeField] private bool m_pause = false;
		public bool Pause 
		{ 
			get => m_pause; 
			set => m_pause = value; 
		}

		[SerializeField] protected bool m_inventory = false;
		public bool Inventory 
		{ 
			get => m_inventory; 
			set => m_inventory = value; 
		}
	}
}