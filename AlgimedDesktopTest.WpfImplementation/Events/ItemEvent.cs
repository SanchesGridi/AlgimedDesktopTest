using Prism.Events;
using System.ComponentModel;

namespace AlgimedDesktopTest.WpfImplementation.Events;

public class ItemEvent<TItem> : PubSubEvent<(TItem Item, string DbMode)> where TItem : INotifyPropertyChanged
{
}
