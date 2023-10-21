using System;
using System.Windows;
using Prism;
using Prism.Ioc;

namespace AlgimedDesktopTest.WpfImplementation.Extensions;

public static class ApplicationExtensions
{
    public static IContainerExtension GetContainer(this Application @this)
    {
        return ((@this as PrismApplicationBase)!.Container as IContainerExtension) ?? throw new ArgumentNullException("@this");
    }
}
