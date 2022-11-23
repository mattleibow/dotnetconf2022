namespace WhatIsNewQuestionMark.Pages;

//public class ThreadLength : ITextileLength<ThreadLength>
public class ThreadLength : ITextileLength
{
    private readonly int length;

    public ThreadLength(int length) =>
        this.length = length;

    public string Color => "Red";

    public override string ToString() =>
        $"{length}m on a bobbin ({Color})";

    public static ThreadLength Zero => new(0);

    public static ThreadLength Longest(ThreadLength a, ThreadLength b) =>
        a.length > b.length ? a : b;

    public static ThreadLength Parse(string s) =>
        new(int.Parse(s));

    public static ThreadLength operator +(ThreadLength a, ThreadLength b) =>
        new(a.length + b.length);
}
