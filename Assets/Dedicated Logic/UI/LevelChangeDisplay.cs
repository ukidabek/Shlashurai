using DG.Tweening;
using Progress;
using TMPro;
using UnityEngine;
using Utilities.ReferenceHost;

public class LevelChangeDisplay : MonoBehaviour
{
	[Inject] private IProgressManager m_progressManager = null;

	[SerializeField] private Transform m_transform;
	[SerializeField] private TMP_Text text = null;

	[SerializeField] private float m_inSpeed = 1f;
	[SerializeField] private float m_outSpeed = 1f;

	private Sequence tween = null;

	private void Awake()
	{
		m_transform.localScale = Vector3.zero;
		tween = DOTween.Sequence()
		.Append(m_transform.DOScale(1, m_inSpeed).SetEase(Ease.InQuad))
		.Append(m_transform.DOScale(0, m_outSpeed).SetEase(Ease.OutQuad))
		.SetAutoKill(false)
		.Pause();
	}

	public void Initialize()
	{
		if (m_progressManager == null) return;
		m_progressManager.OnLevelChanged += OnLevelChanged;
	}

	private void OnLevelChanged(int obj)
	{
		text.text = $"{obj}";
		tween.Rewind();
		tween.Play();
	}

	private void OnDestroy()
	{
		if (m_progressManager == null) return;
		m_progressManager.OnLevelChanged -= OnLevelChanged;
	}

}