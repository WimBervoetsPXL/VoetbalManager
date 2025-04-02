using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoetbalManager.Models
{
    public class Team
    {
		private string _teamName;

		public string TeamName
		{
			get { return _teamName; }
			set { _teamName = value; }
		}

		private Footballer _captain;

		public Footballer Captain
		{
			get { return _captain; }
			set { _captain = value; }
		}

		private List<Footballer> _players = new List<Footballer>();

		public List<Footballer> Players
		{
			get { return _players; }

		}

        public Team(string name)
        {
            _teamName = name;
        }

        public void AddPlayer(Footballer player, bool isCaptain)
        {
            _players.Add(player);

			if(isCaptain)
			{
                _captain = player;
            }	
        }

		public void RemovePlayer(Footballer player)
        {
            _players.Remove(player);
        }

        public override string ToString()
        {
            return this.TeamName;
        }

        public double AverageNumberOfGoals()
        {
            //return this.Players.Average(p => p.NumberOfGoals);
            double sum = 0;
            foreach(Footballer player in Players)
            {
                sum += player.NumberOfGoals;
            }
            return sum / Players.Count;
        }

        public string TeamInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.TeamName} has {this.Players.Count} players.");
            sb.AppendLine("--------------");
            foreach(Footballer player in this.Players)
            {
                sb.AppendLine(player.ToString());
            }
            sb.AppendLine("--------------");
            sb.AppendLine($"Gemiddelde aantal doelpunten: {this.AverageNumberOfGoals().ToString("N2")}");
            return sb.ToString();
        }
    }
}
