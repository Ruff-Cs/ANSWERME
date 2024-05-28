namespace ANSWER_ME.Models;

public partial class CategoryCard : ContentPage
{
    public string TitleText { get; set; }
    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
        propertyName: "titleText",
    returnType: typeof(string),
        declaringType: typeof(CategoryCard),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: TitleTextPropertyChanged
        );
    private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CategoryCard)bindable;
        control.TitleLBL.Text = newValue.ToString();
    }

    public string ImageSource { get; set; }
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
        propertyName: "imageSource",
        returnType: typeof(string),
        declaringType: typeof(CategoryCard),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: ImageSourcePropertyChanged
        );

    private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CategoryCard)bindable;
        control.IllustrationIMG.Source = newValue.ToString();
    }

    public CategoryCard()
    {
        InitializeComponent();
    }
}