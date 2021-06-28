namespace Intership.Data.Parameters
{
    /// <summary>
    /// Model used in controller and service
    /// </summary>
    public class ClientParameter
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public bool AllowEmailNotification { get; set; }
    }
}
