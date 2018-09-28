using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotWShrines
{
    class Shrine
    {
        public string Name { get; }
        public string Region { get; }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value ?? throw new ArgumentNullException
                    ("Description cannot be set to null, but empty is okay.");
            }
        }

        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value ?? throw new ArgumentNullException
                    ("Uh, we weren't supposed to get to this point... null type!?! enum check on selection?");
            }
        }

        private string _completion;
        public string Completion
        {
            get
            {
                return _completion;
            }
            set
            {
                _completion = value ?? throw new ArgumentNullException
                    ("Uh, we weren't supposed to get to this point... null completion!?! enum check on selection?");
            }
        }

        private string _notes;
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value ?? throw new ArgumentNullException
                    ("Notes cannot be set to null, but empty is okay.");
            }
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
