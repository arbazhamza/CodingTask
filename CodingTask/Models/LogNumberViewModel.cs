namespace CodingTask.Models
{
    public class LogNumberViewModel
    {
        // pass data from the controller to the view
        public List<string> Numbers { get; set; } = new List<string>();
        public string? ErrorMessage { get; set; }
    }
}
