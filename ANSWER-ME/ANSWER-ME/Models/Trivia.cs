
namespace ANSWER_ME.Models
{
    public class Trivia
    {
        public int response_code { get; set; }
        public TriviaResult[] results { get; set; }
    }

    public class TriviaResult
    {
        public string type { get; set; }
        public string difficulty { get; set; }
        public string category { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public string[] incorrect_answers { get; set; }
    }
}
