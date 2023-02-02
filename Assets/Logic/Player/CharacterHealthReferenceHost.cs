using UnityEngine;
using Utilities.ReferenceHost;

namespace Logic.Player
{
    [CreateAssetMenu(fileName = "CharacterHealthReferenceHost", menuName = "ReferenceHost/CharacterHealthReferenceHost")]
    public class CharacterHealthReferenceHost : ReferenceHost<CharacterHealth>
    {
    }
}