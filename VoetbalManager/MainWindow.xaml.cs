using System.Windows;
using System.Windows.Controls;
using VoetbalManager.Models;

namespace VoetbalManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Team team = new Team("Kayserispor");
            team.AddPlayer(new Footballer("Murat", "Akin", "midfielder", 2, 3), false);
            team.AddPlayer(new Footballer("Igor", "Akinfejev", "goalkeeper", 4, 0), false);
            team.AddPlayer(new Footballer("Kerem", "Aktürkoglu", "attacker", 5, 10), true);
            team.AddPlayer(new Footballer("Chuba", "Akpom", "defender", 3, 1), false);

            teamsComboBox.Items.Add(team);
            teamsComboBox.SelectedIndex = 0;
        }

        private void TeamsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            // TODO: Controleer of een team geselecteerd is en toon vervolgens al de informatie van het team.
            // Selecteer vervolgens automatisch de eerste speler van het geselecteerde Team.
            footballersListBox.Items.Clear();
            
            Team selectedTeam = teamsComboBox.SelectedItem as Team;
            if(selectedTeam != null)
            {
                foreach (Footballer player in selectedTeam.Players)
                {
                    footballersListBox.Items.Add(player);
                }
            }
        }

        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Verwijder de geselecteerde speler van het geselecteerde team.
            Footballer selectedPlayer = footballersListBox.SelectedItem as Footballer;

            if(selectedPlayer != null)
            {
                Team selectedTeam = teamsComboBox.SelectedItem as Team;

                if(selectedTeam != null)
                {
                    selectedTeam.RemovePlayer(selectedPlayer);
                }
            }
        }

        private void FootballersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Toon het resultaat van Information() van de geselecteerde speler (footballer) in playerInfoTextBox.
            Footballer selectedPlayer = footballersListBox.SelectedItem as Footballer;

            if (selectedPlayer != null) 
            {
                playerInfoTextBox.Text = selectedPlayer.Informatie();
            }
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Maak een Footballer aan op basis van de invulvelden en voeg de Footballer toe aan het geselecteerde Team.
            Team selectedTeam = teamsComboBox.SelectedItem as Team;

            if (selectedTeam != null)
            {
                Footballer newPlayer = new Footballer(
                firstNameTextBox.Text,
                lastNameTextBox.Text,
                positionTextBox.Text,
                int.Parse(jerseyNumberTextBox.Text),
                int.Parse(numberOfGoalsTextBox.Text));

                selectedTeam.AddPlayer(newPlayer, isCaptainCheckBox.IsChecked.Value);

                UpdateUI();
            }
        }

        private void AddTeamButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Maak een Team aan op basis van de inhoud uit teamNameTextBox en voeg het team toe aan teamsComboBox.
            Team newTeam = new Team(teamNameTextBox.Text);
            teamsComboBox.Items.Add(newTeam);

            UpdateUI();
        }
    }
}
