﻿using UnityEngine;

namespace Utilities.Items
{
    public class ItemData : MonoBehaviour
    {
        [SerializeField] private string _displayName = string.Empty;
        public string DisplayName => _displayName;
    }
}