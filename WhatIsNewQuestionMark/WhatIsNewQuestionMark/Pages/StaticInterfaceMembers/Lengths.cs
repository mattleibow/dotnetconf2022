namespace WhatIsNewQuestionMark.Pages;

//public class ThreadLength : ITextileLength<ThreadLength>
public class ThreadLength : ITextileLength
{
    public static ThreadLength Zero => new(0);

    private readonly int length;

    public ThreadLength(int length) =>
        this.length = length;

    public string Color => "Red";

    public override string ToString() =>
        $"{length}m on a bobbin ({Color})";

    public static ThreadLength Longest(ThreadLength a, ThreadLength b) =>
        a.length > b.length ? a : b;

    public static ThreadLength Parse(string s) =>
        new(int.Parse(s));

    public static ThreadLength operator +(ThreadLength a, ThreadLength b) =>
        new(a.length + b.length);
}



//public class FabricLength : ITextileLength<FabricLength>
public class FabricLength : ITextileLength
{
    public static FabricLength Zero => new(0);

    private readonly int length;

    public FabricLength(int length) =>
        this.length = length;

    public string Color => "Red";

    public override string ToString() =>
        $"{length}m roll of fabric ({Color})";

    public static FabricLength Longest(FabricLength a, FabricLength b) =>
        a.length > b.length ? a : b;

    public static FabricLength Parse(string s) =>
        new(int.Parse(s));

    public static FabricLength operator +(FabricLength a, FabricLength b) =>
        new(a.length + b.length);
}
