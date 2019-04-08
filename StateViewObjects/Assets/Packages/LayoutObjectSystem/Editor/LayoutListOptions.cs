namespace LayoutObjectSystem.Editor
{
    using System;

    [Flags]
    public enum LayoutListOptions
    {
        Elements = 0,
        Size = 1,
        ActionButtons = 2,
        Default = Elements,
        All = Elements | ActionButtons
    }
}