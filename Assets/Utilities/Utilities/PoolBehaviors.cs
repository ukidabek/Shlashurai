using System.Collections.Generic;
using UnityEngine;

namespace Utilities.General
{
    public static class PoolBehaviors
    {


		public static void DefaultOnPollElementSelectedBehavior(Component component) => component.gameObject.SetActive(true);
        
        public static void DefaultOnPollElementReturnedBehavior(Component component) => component.gameObject.SetActive(false);
    }
}