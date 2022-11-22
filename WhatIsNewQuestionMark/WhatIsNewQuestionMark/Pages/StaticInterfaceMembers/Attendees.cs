namespace WhatIsNewQuestionMark.Pages;

public class WesternAttendee : IAttendee
{
    public WesternAttendee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }

    public string LastName { get; }

    public static IAttendee FromFullName(string fullname)
    {
        var other = AttendeeUtils.Parse(fullname);
        return new WesternAttendee(other.FirstName, other.LastName);
    }

    public static IAttendee Add(IAttendee bride, IAttendee groom) =>
        new WesternAttendee(bride.FirstName, groom.LastName);
}



public class IndonesianAttendee : IAttendee
{
    public IndonesianAttendee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }

    public string LastName { get; }

    public static IAttendee FromLongName(string longname)
    {
        var other = AttendeeUtils.Parse(longname);
        return new IndonesianAttendee(other.FirstName, other.LastName);
    }

    public static IAttendee Add(IAttendee bride, IAttendee groom)
    {
        var lastName = $"{groom.LastName}-{bride.LastName}";
        return new IndonesianAttendee(bride.FirstName, lastName);
    }
}
