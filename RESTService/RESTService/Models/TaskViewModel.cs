using System;

namespace RESTService.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PublishDate { get; set; }
        public string AuthorNickname { get; set; }
        public int AuthorId { get; set; }

        public TaskViewModel()
        {
            PublishDate = DateTime.Now.ToShortDateString();
        }
    }
}