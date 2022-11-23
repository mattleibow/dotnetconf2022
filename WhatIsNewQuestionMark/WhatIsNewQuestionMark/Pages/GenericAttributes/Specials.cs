namespace WhatIsNewQuestionMark.Pages;

interface ISpecial
{
    bool IsSuperSpecial { get; }
}



class SuperSpecial : ISpecial
{
    public bool IsSuperSpecial { get; } = true;
}

class NormalSpecial : ISpecial
{
    public bool IsSuperSpecial { get; } = false;
}

class NotSpecial
{
}
