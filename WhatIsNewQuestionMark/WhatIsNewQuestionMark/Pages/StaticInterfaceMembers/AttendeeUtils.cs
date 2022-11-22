namespace WhatIsNewQuestionMark.Pages;

static class AttendeeUtils
{
    public static IAttendee Parse(string? fullname)
    {
        var names = fullname?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        if (names is null || names.Length != 2)
            throw new InvalidOperationException("We only support people with 2 names!");

        var first = names[0];
        var last = names[1];

        return new InternalOnlyAttendee(first, last);
    }

    public static IAttendee Add(IAttendee bride, IAttendee groom, bool isWestern)
    {
        var lastName = isWestern
            ? groom.LastName
            : $"{groom.LastName}-{bride.LastName}";
        return new InternalOnlyAttendee(bride.FirstName, lastName);
    }

    public static IAttendee Multiply(IAttendee mother, string babyName, bool isWestern)
    {
        var lastName = isWestern
            ? mother.LastName
            : mother.LastName.Split("-")[0];
        return new InternalOnlyAttendee(babyName, lastName);
    }
}
