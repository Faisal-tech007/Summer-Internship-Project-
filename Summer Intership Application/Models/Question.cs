namespace Summer_Intership_Application.Models
{
    public class Question
    {
            public int Id { get; set; }
            public string Type { get; set; }
            public string QuestionText { get; set; }
            public List<string> Options { get; set; }

    }
}
