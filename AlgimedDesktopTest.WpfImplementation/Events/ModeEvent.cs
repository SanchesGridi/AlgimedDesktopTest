using AlgimedDesktopTest.WpfImplementation.Models;
using Prism.Events;

namespace AlgimedDesktopTest.WpfImplementation.Events;

public class ModeEvent : PubSubEvent<(ModeModel Item, string DbMode)>
{
}
