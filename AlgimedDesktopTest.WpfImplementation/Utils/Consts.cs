namespace AlgimedDesktopTest.WpfImplementation.Utils;

public static class Consts
{
    public static string XamlEditKey => Keys.EditKey;
    public static string XamlAddKey => Keys.AddKey;

    public static class Keys
    {
        public const string TitleKey = "title";
        public const string DetailsKey = "details";
        public const string DbModeKey = "db_mode";
        public const string EditKey = "edit";
        public const string AddKey = "add";
        public const string ItemKey = "item";
    }

    public static class Dialogs
    {
        public const string ExceptionDialog = "exception_dialog";
    }

    public static class ViewNames
    {
        public const string ModeItemView = nameof(ModeItemView);
        public const string ListView = nameof(ListView);
    }
}
