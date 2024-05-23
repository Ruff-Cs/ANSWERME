namespace ANSWER_ME.Models;

public partial class CategoryCard : ContentPage
{
    public string titleText { get; set; }
    public static readonly BindableProperty titleTextProperty = BindableProperty.Create(
        propertyName: "titleText",
    returnType: typeof(string),
        declaringType: typeof(CategoryCard),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: titleTextPropertyChanged
        );
    private static void titleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CategoryCard)bindable;
        control.TitleLBL.Text = newValue.ToString();
    }

    public string imageSource { get; set; }
    public static readonly BindableProperty imageSourceProperty = BindableProperty.Create(
        propertyName: "imageSource",
        returnType: typeof(string),
        declaringType: typeof(CategoryCard),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: imageSourcePropertyChanged
        );

    private static void imageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CategoryCard)bindable;
        control.IllustrationIMG.Source = newValue.ToString();
    }

    public CategoryCard()
    {
        InitializeComponent();
    }
}