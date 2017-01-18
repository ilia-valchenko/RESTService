using System;

namespace RESTService.App_Code
{
    [Serializable]
    public class Task
    {
        public string Title
        {
            get
            {
                return title;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    title = "untitled";
                else
                    title = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    description = String.Empty;
                else
                    description = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            private set
            {
                date = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    author = "Unknown";
                else
                    author = value;
            }
        }

        public Task() : this("Untitled", String.Empty, "Unknown") { }

        public Task(string title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;
            Date = DateTime.Now;
        }

        private string title;
        private string description;
        private string author;
        private DateTime date;
    }
}