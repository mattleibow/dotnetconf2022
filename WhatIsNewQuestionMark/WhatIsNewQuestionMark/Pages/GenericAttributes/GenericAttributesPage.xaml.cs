using WhatIsNewQuestionMark.Pages.GenericAttributes;

namespace WhatIsNewQuestionMark.Pages;

public partial class GenericAttributesPage : ContentPage
{
    private object potentiallySpecial;

    public GenericAttributesPage()
    {
        InitializeComponent();

        BindingContext = this;
    }

    public object PotentiallySpecial
    {
        get => potentiallySpecial;
        set
        {
            potentiallySpecial = value;
            OnPropertyChanged();
        }
    }

    public IList<object> AllItems { get; } =
        new List<object>
        {
            new SpecialObject(),
            new AlsoSpecialObject(),
            "Plain String",
            42,
            new NotSpecialObject(),
            new FakeSpecialObject(),
        };
}
