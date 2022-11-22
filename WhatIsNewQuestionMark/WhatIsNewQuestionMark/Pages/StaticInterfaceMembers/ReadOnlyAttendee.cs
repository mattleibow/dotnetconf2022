namespace WhatIsNewQuestionMark.Pages;

class ReadOnlyAttendee : IAttendee
{
    public ReadOnlyAttendee(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }

    public string FirstName { get; }

    public string LastName { get; }
}
