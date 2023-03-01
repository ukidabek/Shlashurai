using System;
using UnityEngine;

namespace Shlashurai.PickUp
{
	public class CurrencyItemPickUpHandler : ItemPickUpHandler<CurrencyItemComponent>
	{
		public override void Handle(object pickUp) => m_itemComponent.Apply();
	}
}
