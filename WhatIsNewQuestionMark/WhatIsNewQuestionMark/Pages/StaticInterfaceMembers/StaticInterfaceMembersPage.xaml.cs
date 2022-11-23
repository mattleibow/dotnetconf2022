namespace WhatIsNewQuestionMark.Pages;

public partial class StaticInterfaceMembersPage : ContentPage
{
    public StaticInterfaceMembersPage()
    {
        InitializeComponent();

        AddLengthCommand = new(OnAddLength);
        JoinLengthsCommand = new(OnJoinLengths);
        StocktakeCommand = new(OnStocktake);

        BindingContext = this;
    }

    public TextileFactoryFloor<ThreadLength> Factory { get; } = new();

    public Command<string> AddLengthCommand { get; }

    void OnAddLength(string length) =>
        Factory.ManufactureLength(length);

    public Command<IList<object>> JoinLengthsCommand { get; }

    void OnJoinLengths(IList<object> lengths) =>
        Factory.JoinLengths(lengths.OfType<ThreadLength>());

    public Command StocktakeCommand { get; }

    async void OnStocktake() =>
        await DisplayAlert(
            "Stock",
            $"Total: {Factory.MeasureTotalLength()}. Longest: {Factory.FindLongest()}",
            "OK");
}
