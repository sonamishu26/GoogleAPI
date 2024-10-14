namespace BaseClientService
{
    internal class Initializer
    {
        public Initializer()
        {
        }

        public UserCredential HttpClientInitializer { get; set; }
        public string ApplicationName { get; set; }
    }
}