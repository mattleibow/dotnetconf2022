namespace WhatIsNewQuestionMark.Pages;

//[Special<SuperSpecial>]
[Special(typeof(SuperSpecial))]
class SpecialObject
{
    public override string ToString() => "Special Object 😁";
}

//[Special<NormalSpecial>]
[Special(typeof(NormalSpecial))]
class AlsoSpecialObject
{
    public override string ToString() => "Another Special Object 😁";
}

class NotSpecialObject
{
    public override string ToString() => "Not special at all 😭";
}



//[Special<NotSpecial>]
[Special(typeof(NotSpecial))]
class FakeSpecialObject
{
    public override string ToString() => "A real bad boy 😈";
}
