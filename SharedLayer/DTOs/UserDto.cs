namespace SharedLayer.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int TokensAvailable { get; set; }
        // Add other properties as needed
    }
    public class CreateUserDto
    {
        
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        // Add other properties as needed
    }
}
