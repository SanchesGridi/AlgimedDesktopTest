using System.Windows;
using System.Windows.Input;

namespace AlgimedDesktopTest.WpfImplementation.Wpf;

public static class AttachedProperties
{
    public static readonly DependencyProperty InputBindingsProperty = DependencyProperty
        .RegisterAttached("InputBindings", typeof(InputBindingCollection), typeof(AttachedProperties),
            new FrameworkPropertyMetadata(new InputBindingCollection(),(sender, e) => {
                if (sender is not UIElement element) return;
                element.InputBindings.AddRange((InputBindingCollection)e.NewValue);
            })
        );

    public static InputBindingCollection GetInputBindings(UIElement element)
    {
        return (InputBindingCollection)element.GetValue(InputBindingsProperty);
    }

    public static void SetInputBindings(UIElement element, InputBindingCollection inputBindings)
    {
        element.SetValue(InputBindingsProperty, inputBindings);
    }
}
