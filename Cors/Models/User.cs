namespace Cors.Models
{
    public class User
    {
        public Guid Id { get; set; }    
        public string name { get; set; }
        public int Age { get; set; }

        public User(string name, int age)
        {
            this.name = name;
            Age = age;
            Id = Guid.NewGuid();
        }
        public User()
        {
            
        }
    }
}
