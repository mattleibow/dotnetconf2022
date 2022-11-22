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

        return new ReadOnlyAttendee(first, last);
    }

    public static IAttendee Add(IAttendee bride, IAttendee groom)
    {
        var lastName = $"{groom.LastName}-{bride.LastName}";
        return new ReadOnlyAttendee(bride.FirstName, lastName);
    }

    public static IAttendee Multiply(IAttendee mother, string babyName)
    {
        var lastNames = mother.LastName.Split("-");
        return new ReadOnlyAttendee(babyName, lastNames[0]);
    }
}
