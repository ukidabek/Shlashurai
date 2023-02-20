using UnityEngine;

namespace Money
{
	[CreateAssetMenu(fileName = "ImageCurrencyComponent", menuName = "Currency/Component/ImageCurrencyComponent")]
	public class ImageCurrencyComponent : CurrencyComponent
	{
		[SerializeField] private Sprite m_image = null;
		public Sprite Image => m_image;
	}
}
