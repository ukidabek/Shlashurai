using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities.States;

public class GameEndScreenStateLogic : StateLogic
{
	[SerializeField] private Image m_background = null;
	[SerializeField] private TMP_Text m_text = null;
	[Space]
	[SerializeField] private float m_colorDuration = 1f;
	[SerializeField] private float m_scaleInDuration = 1f;
	[SerializeField] private float m_scaleOutDuration = .5f;

	private Sequence m_backgroundSequence = null;
	private Sequence m_textSequence = null;

	private void Awake()
	{
		var targetColor = m_background.color;
		var formColor = m_background.color;
		formColor.a = 0;

		m_backgroundSequence = DOTween
			.Sequence()
			.Append(m_background.DOColor(targetColor, m_colorDuration).From(formColor, true).SetEase(Ease.InQuad))
			.SetAutoKill(false)
			.Pause();

		var textTransform = m_text.transform;
		m_textSequence = DOTween
			.Sequence()
			.Append(textTransform.DOScale(1.2f, m_scaleInDuration).From(0, true).SetEase(Ease.InQuad))
			.Append(textTransform.DOScale(1f, m_scaleOutDuration).SetEase(Ease.OutQuad))
			.SetAutoKill(false)
			.Pause();
	}

	public override void Activate()
	{
		base.Activate();
		PlayTweens();
	}

	[ContextMenu("PlayTweens")]
	public void PlayTweens()
	{
		m_backgroundSequence.Rewind();
		m_backgroundSequence.Play();

		m_textSequence.Rewind();
		m_textSequence.Play();
	}
}