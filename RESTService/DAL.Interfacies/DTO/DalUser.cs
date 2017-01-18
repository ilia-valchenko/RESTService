namespace DAL.Interfacies.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
