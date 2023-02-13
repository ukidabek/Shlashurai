using System.Collections;

namespace Utilities.Containers
{
	public interface IContainerAnimatorManager
	{
		IEnumerator Open();
		IEnumerator Close();
	}
}