namespace ZeldaShrineTracker
{
    public class Shrine
    {
        public readonly string Name;
        public readonly string Region;

        private string _description;
        public string Description
        {
            get => _description;
            set => _description = value ?? string.Empty;
        }

        private string _type;
        public string Type
        {
            get => _type;
            set => _type = value ?? string.Empty;
        }

        private string _completion;
        public string Completion
        {
            get => _completion;
            set => _completion = value ?? string.Empty;
        }

        private string _notes;
        public string Notes
        {
            get => _notes;
            set => _notes = value ?? string.Empty;
        }

        public Shrine(string name, string region, string description,
                      string type, string completion, string notes)
        {
            Name = name;
            Region = region;
            _description = description;
            _type = type;
            _completion = completion;
            _notes = notes;
        }
    }
}
