namespace Budgets.DTOs{
    
    public class UserUpdateDTO(){
        
        public int Id { get; set; }
        public string Name { get; set; }    
        public required string Username { get; set; }
        public required string Password { get; set; }

    }
}
