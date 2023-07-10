using System;
using UnityEngine;
using Utilities.Configuration;

namespace Shlashurai.Character
{
	[Serializable]
	public class Name : ISetting
	{
		[SerializeField] private string m_name = null;
		public static implicit operator string (Name name) => name.m_name;
    }
}