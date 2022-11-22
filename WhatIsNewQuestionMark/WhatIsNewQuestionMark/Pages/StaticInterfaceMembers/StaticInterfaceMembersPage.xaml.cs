using System.Collections.ObjectModel;

namespace WhatIsNewQuestionMark.Pages;

public partial class StaticInterfaceMembersPage : ContentPage
{
    private IAttendee? selectedGroom;
    private IAttendee? selectedBride;
    private IAttendee? selectedParent;

    public StaticInterfaceMembersPage()
    {
        InitializeComponent();

        AddAttendeeCommand = new(OnAddAttendee);
        AddIndonesianAttendeeCommand = new(OnAddIndonesianAttendee);
        AddWesternAttendeeCommand = new(OnAddWesternAttendee);
        PerformCeremonyCommand = new(OnPerformCeremony);
        StartFamilyCommand = new(OnStartFamily);

        BindingContext = this;
    }

    // list of attendees

    public ObservableCollection<IAttendee> Register { get; } = new();

    // add a new attendee

    public Command<string> AddAttendeeCommand { get; }

    private async void OnAddAttendee(string fullname)
    {
        try
        {
            // var attendee = IAttendee.Parse(fullname);
            var attendee = AttendeeUtils.Parse(fullname);
            Register.Add(attendee);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    public Command<string> AddIndonesianAttendeeCommand { get; }

    private async void OnAddIndonesianAttendee(string fullname)
    {
        try
        {
            // var attendee = IndonesianAttendee.Parse(fullname);
            var attendee = IndonesianAttendee.FromLongName(fullname);
            Register.Add(attendee);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    public Command<string> AddWesternAttendeeCommand { get; }

    private async void OnAddWesternAttendee(string fullname)
    {
        try
        {
            // var attendee = WesternAttendee.Parse(fullname);
            var attendee = WesternAttendee.FromFullName(fullname);
            Register.Add(attendee);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    // perform a marriage

    public IAttendee? SelectedGroom
    {
        get => selectedGroom;
        set
        {
            selectedGroom = value;
            OnPropertyChanged();
        }
    }

    public IAttendee? SelectedBride
    {
        get => selectedBride;
        set
        {
            selectedBride = value;
            OnPropertyChanged();
        }
    }

    public Command PerformCeremonyCommand { get; }

    private async void OnPerformCeremony()
    {
        try
        {
            _ = SelectedGroom ?? throw new InvalidOperationException("A marriage requires a groom of some sort!");
            _ = SelectedBride ?? throw new InvalidOperationException("A marriage requires a bride of some sort!");

            // var wife = SelectedBride + SelectedGroom;
            var wife = AttendeeUtils.Add(
                SelectedBride,
                SelectedGroom,
                SelectedBride is WesternAttendee);

            Register.Remove(SelectedBride);
            Register.Add(wife);

            SelectedGroom = null;
            SelectedBride = null;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    // start a family

    public IAttendee? SelectedParent
    {
        get => selectedParent;
        set
        {
            selectedParent = value;
            OnPropertyChanged();
        }
    }

    public Command<string> StartFamilyCommand { get; }

    private async void OnStartFamily(string babyName)
    {
        try
        {
            _ = SelectedParent ?? throw new InvalidOperationException("A new baby requires a parent of some sort!");

            // var baby = SelectedParent * babyName;
            var baby = AttendeeUtils.Multiply(
                SelectedParent,
                babyName,
                SelectedParent is WesternAttendee);

            Register.Add(baby);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
