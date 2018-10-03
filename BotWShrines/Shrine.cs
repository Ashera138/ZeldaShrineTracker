namespace ZeldaShrineTracker
{
    public class Shrine
    {
        public string Name = string.Empty;
        public string Region = string.Empty;

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set => _description = value ?? string.Empty;
        }

        private string _type = string.Empty;
        public string Type
        {
            get => _type;
            set => _type = value ?? string.Empty;
        }

        public bool Completed { get; set; }

        private string _notes = string.Empty;
        public string Notes
        {
            get => _notes;
            set => _notes = value ?? string.Empty;
        }
    }
}
