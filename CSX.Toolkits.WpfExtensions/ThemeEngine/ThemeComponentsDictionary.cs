using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public class ThemeComponentsDictionary : ResourceDictionary
{
    // Initialization

    private static readonly bool IsDesignTime
        = (bool)DesignerProperties
        .IsInDesignModeProperty
        .GetMetadata(typeof(DependencyObject))
        .DefaultValue;

    // Cache

    private static readonly Dictionary<Uri, ResourceDictionary> _cache = new();
    public static Dictionary<Uri, ResourceDictionary> SharedDictionaries => _cache;

    // Uri

    private Uri? _source;

    public new Uri Source
    {
        get => _source ?? new("Unknown");
        set
        {
            _source = value;

            // If design time, load anyway
            if (!_cache.ContainsKey(value) || IsDesignTime)
            {
                // Pass to base class if not loaded
                base.Source = value;

                // If runtime, cache it for reuse
                if (!IsDesignTime)
                    _cache.Add(value, this);
            }

            // If the dictionary is already loaded, add it from cache
            else MergedDictionaries.Add(_cache[value]);
        }
    }
}