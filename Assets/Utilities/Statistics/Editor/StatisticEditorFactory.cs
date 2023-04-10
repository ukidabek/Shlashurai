namespace Shlashurai.Statistics
{
	internal class StatisticEditorFactory
	{
		public StatisticEditor Build(Statistic statistic)
		{
			switch (statistic)
			{
				default:
					return new DefaultStatisticEditor(statistic);
			}
		}
	}
}