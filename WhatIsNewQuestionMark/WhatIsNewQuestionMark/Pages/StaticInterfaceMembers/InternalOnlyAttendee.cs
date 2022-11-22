namespace WhatIsNewQuestionMark.Pages;

internal class InternalOnlyAttendee : IAttendee
{
    public InternalOnlyAttendee(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }

    public string FirstName { get; }

    public string LastName { get; }
}
