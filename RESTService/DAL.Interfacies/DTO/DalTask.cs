using System;

namespace DAL.Interfacies.DTO
{
    public class DalTask : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int UserId { get; set; }
    }
}
