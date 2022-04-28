namespace CustomExpanderView;

public partial class CustomExpander : ContentView
{
    private static readonly string ArrowDown = "arrow_down.png";
    private static readonly string ArrowUp = "arrow_up.png";

    private string _expandIcon;

    public static readonly BindableProperty IsExpandedProperty =
        BindableProperty.CreateAttached(
            nameof(IsExpanded),
            typeof(bool),
            typeof(CustomExpander),
            false,
            BindingMode.TwoWay);

    public static readonly BindableProperty TitleProperty =
        BindableProperty.CreateAttached(
            nameof(Title),
            typeof(string),
            typeof(CustomExpander),
            string.Empty);


    public static readonly BindableProperty BodyContentTemplateProperty =
        BindableProperty.CreateAttached(
            nameof(BodyContentTemplate),
            typeof(DataTemplate),
            typeof(CustomExpander),
            null,
            BindingMode.TwoWay,
            propertyChanged: ContentBodyTemplatePropertyChanged);

    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public bool IsExpanded
    {
        get { return (bool)GetValue(IsExpandedProperty); }
        set { SetValue(IsExpandedProperty, value); }
    }

    public DataTemplate BodyContentTemplate
    {
        get { return (DataTemplate)GetValue(BodyContentTemplateProperty); }
        set{ SetValue(BodyContentTemplateProperty, value); }
    }

    public string ExpandIcon
    {
        get => _expandIcon;
        set
        {
            _expandIcon = value;
            OnPropertyChanged(nameof(ExpandIcon));
        }
    }

    public CustomExpander()
    {
        InitializeComponent();
        Init();
        BindingContext = this;
    }

    private void Init()
    {
        ExpandIcon = ArrowDown;
        BodyContentView.IsVisible = false;
    }

    private static void ContentBodyTemplatePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var cp = (CustomExpander)bindable;

        var template = cp.BodyContentTemplate;
        if (template != null)
        {
            var content = (View)template.CreateContent();
            cp.BodyContentView.Content = content;
        }
        else
        {
            cp.BodyContentView.Content = null;
        }
    }

    private void HeaderContent_OnTapped(object sender, EventArgs e)
    {
        if (!IsExpanded)
        {
            BodyContentView.Opacity = 0;
        }

        IsExpanded = !IsExpanded;
        ExpandIcon = IsExpanded ? ArrowUp : ArrowDown;

        BodyContentView.IsVisible = IsExpanded;
        BodyContentView.FadeTo(1, 400, Easing.SpringOut);
    }
}