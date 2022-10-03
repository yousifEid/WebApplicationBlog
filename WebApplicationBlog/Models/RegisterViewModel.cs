namespace WebApplicationBlog.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Gender { get; set; }

        public string? DateBirth { get; set; }

        public string? Mail { get; set; }

        public string? Password { get; set; }

        public string? Photo { get; set; }

        public bool TermsConditions { get; set; }

    }
}
