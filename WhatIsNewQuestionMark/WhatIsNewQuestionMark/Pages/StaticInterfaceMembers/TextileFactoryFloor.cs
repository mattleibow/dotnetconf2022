using System.Collections.ObjectModel;

namespace WhatIsNewQuestionMark.Pages;

//public class TextileFactoryFloor<TLength>
//    where TLength : ITextileLength<TLength>
public class ThreadTextileFactoryFloor : TextileFactoryFloor<ThreadLength>
{
    public override void ManufactureLength(string length)
    {
        var newLength = ThreadLength.Parse(length);
        LengthsOnSite.Add(newLength);
    }

    public override void JoinLengths(IEnumerable<ThreadLength> lengths)
    {
        var newLength = ThreadLength.Zero;
        foreach (var length in lengths.ToArray())
        {
            newLength += length;
            LengthsOnSite.Remove(length);
        }
        LengthsOnSite.Add(newLength);
    }

    public override ThreadLength MeasureTotalLength()
    {
        var totalLength = ThreadLength.Zero;
        foreach (var length in LengthsOnSite)
        {
            totalLength += length;
        }
        return totalLength;
    }

    public override ThreadLength FindLongest()
    {
        var current = ThreadLength.Zero;
        foreach (var length in LengthsOnSite)
        {
            current = ThreadLength.Longest(length, current);
        }
        return current;
    }
}



public abstract class TextileFactoryFloor<TLength>
    where TLength : ITextileLength
{
    public ObservableCollection<TLength> LengthsOnSite { get; } = new();

    public abstract void ManufactureLength(string length);

    public abstract void JoinLengths(IEnumerable<TLength> lengths);

    public abstract TLength MeasureTotalLength();

    public abstract TLength FindLongest();
}
