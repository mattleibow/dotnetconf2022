using System.Collections.ObjectModel;

namespace WhatIsNewQuestionMark.Pages;

public class TextileFactoryFloor<TLength>
    where TLength : ITextileLength<TLength>
{
    public ObservableCollection<TLength> LengthsOnSite { get; } = new();

    public void ManufactureLength(string length)
    {
        var newLength = TLength.Parse(length);
        LengthsOnSite.Add(newLength);
    }

    public void JoinLengths(IEnumerable<TLength> lengths)
    {
        var newLength = TLength.Zero;
        foreach (var length in lengths.ToArray())
        {
            newLength += length;
            LengthsOnSite.Remove(length);
        }
        LengthsOnSite.Add(newLength);
    }

    public TLength MeasureTotalLength()
    {
        var totalLength = TLength.Zero;
        foreach (var length in LengthsOnSite)
        {
            totalLength += length;
        }
        return totalLength;
    }

    public TLength FindLongest()
    {
        var current = TLength.Zero;
        foreach (var length in LengthsOnSite)
        {
            current = TLength.Longest(length, current);
        }
        return current;
    }
}
