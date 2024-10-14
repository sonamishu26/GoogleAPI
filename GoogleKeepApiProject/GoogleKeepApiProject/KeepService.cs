internal class KeepService
{
    public KeepService(BaseClientService.Initializer initializer)
    {
        Initializer = initializer;
    }

    public static object Scope { get; internal set; }
    public BaseClientService.Initializer Initializer { get; }
    public object Notes { get; internal set; }
}