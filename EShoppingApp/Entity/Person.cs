namespace EShoppingApp.Entity
{
    public abstract class Person:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
