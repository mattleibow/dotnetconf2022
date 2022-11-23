namespace WhatIsNewQuestionMark.Pages;

//class SpecialAttribute<T> : Attribute
//    where T : ISpecial
//{
//}
class SpecialAttribute : Attribute
{
    public SpecialAttribute(Type specialType)
    {
        if (!typeof(ISpecial).IsAssignableFrom(specialType))
            throw new InvalidOperationException("All types must be ISpecial!");

        SpecialType = specialType;
    }

    public Type SpecialType { get; }
}
