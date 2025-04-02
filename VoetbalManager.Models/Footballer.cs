using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace VoetbalManager.Models
{
    public class Footballer
    {
		private string _firstName;

		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}
		private string _lastName;

		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		public List<string> Positions = new List<string>() { "goalkeeper", "attacker", "midfielder", "defender" };
        
		private string _position;

        public string Position
		{
			get { return _position; }
			set 
			{
				if (Positions.Any(p => p.Equals(value)))
				{
					_position = value;
				}
				else
				{
					throw new ArgumentException("Ongeldige positie");
				}
			}
		}
		private int _jerseyNumber;

		public int JerseyNumber
        {
			get { return _jerseyNumber; }
			set { _jerseyNumber = value; }
		}
		private int _numberOfGoals;

		public int NumberOfGoals
        {
			get { return _numberOfGoals; }
			set { _numberOfGoals = value; }
		}

        public Footballer(string firstName, string lastName, string position, int jerseyNumber, int numberOfGoals)
        {
            _firstName = firstName;
            _lastName = lastName;
            _position = position;
            _jerseyNumber = jerseyNumber;
            _numberOfGoals = numberOfGoals;
        }

		public Footballer(string firstName, string lastName, int jerseyNumber)
		{
			_firstName = firstName;
			_lastName = lastName;
			_jerseyNumber = jerseyNumber;
			_position = "midfielder";
			_numberOfGoals = 0;
        }

        public override string ToString()
        {
			return $"{LastName} - {FirstName}";
        }

		public string Informatie()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{this.FirstName} {this.LastName} ({this.JerseyNumber})");
			sb.AppendLine($"Doelpunten: {this.NumberOfGoals}");
			sb.AppendLine($"Positie: {this.Position}");
			return sb.ToString();
		}
    }
}
