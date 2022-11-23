namespace WhatIsNewQuestionMark.Pages;

public partial class StaticInterfaceMembersPage : ContentPage
{
    public StaticInterfaceMembersPage()
    {
        InitializeComponent();

        AddLengthCommand = new(OnAddLength);
        StocktakeCommand = new(OnStocktake);

        BindingContext = this;
    }

    public ThreadTextileFactoryFloor Factory { get; } = new();

    public Command<string> AddLengthCommand { get; }

    void OnAddLength(string length) =>
        Factory.ManufactureLength(length);

    public Command StocktakeCommand { get; }

    async void OnStocktake() =>
        await DisplayAlert(
            "Stock",
            $"Total: {Factory.MeasureTotalLength()}",
            "OK");
}
