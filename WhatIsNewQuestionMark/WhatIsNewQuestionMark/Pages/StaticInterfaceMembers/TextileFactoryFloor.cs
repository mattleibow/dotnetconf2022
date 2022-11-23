using System.Collections.ObjectModel;

namespace WhatIsNewQuestionMark.Pages;

//public class TextileFactoryFloor<TLength>
//    where TLength : ITextileLength<TLength>
public class TextileFactoryFloor
{
    public ObservableCollection<ThreadLength> LengthsOnSite { get; } = new();

    public void ManufactureLength(string length)
    {
        var newLength = ThreadLength.Parse(length);
        LengthsOnSite.Add(newLength);
    }

    public ThreadLength MeasureTotalLength()
    {
        var totalLength = ThreadLength.Zero;
        foreach (var length in LengthsOnSite)
        {
            totalLength += length;
        }
        return totalLength;
    }
}
