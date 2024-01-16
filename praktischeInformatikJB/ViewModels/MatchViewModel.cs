﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using sportapiwrapper.Enums;
using sportapiwrapper.InternalLogic;
using sportapiwrapper.models;
using sportapiwrapper.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace praktischeInformatikJB.ViewModels
{
    public partial class MatchViewModel : ObservableObject
    {
        public List<MatchData> MatchData { get; }       
        public string? TeamOneID {  get; set; }
        public string? TeamTwoID { get; set; }
        public string? TeamOne {  get; set; }
        public string? TeamTwo { get; set; }
        public int? PointsTeam1 { get; set; }
        public int? PointsTeam2 { get; set; }
        public string? TeamOnePictureURL { get; set; }
        public string? TeamTwoPictureURL { get; set; }
        public DateTime BerlinTime { get; set; }
        public List<List<string>> PoissonResults { get; set; }
                                      

        public MatchViewModel(MatchData match, string LeagueShortCut) // Es wird immer ein Match übergeben 
        {
            TimeZoneInfo berlinTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

            BerlinTime = TimeZoneInfo.ConvertTimeFromUtc(match.MatchDateTimeUTC.Value, berlinTimeZone);           

            TeamOneID = match.Team1.TeamId.ToString(); //TeamID muss in der API abfrage ein string sein, auch wenn es laut dokumentation ein int ist, warum auch immer
            TeamTwoID = match.Team2.TeamId.ToString();
            TeamOne = match.Team1.TeamName;
            TeamTwo = match.Team2.TeamName;
            TeamOnePictureURL = match.Team1.TeamIconUrl;
            TeamTwoPictureURL = match.Team2.TeamIconUrl;           

            DefineMatchResult(match);

            List<MatchData>? matchhistory = SportsApi.GetTwoClubsMatchHistory(TeamOneID, TeamTwoID, out ReturnStatus status);  

            List<MatchData>? matchDataInHistory =  FindGamesInHistory(matchhistory); //Eine Funktion die nur die Vergangenen Begegnungen mit Ergebnis ausgeben soll

            double[] WinsPerTeam = CountWins(matchDataInHistory, match.Team1.TeamId, match.Team2.TeamId, LeagueShortCut); //Eine Funktion die anhand der Vergangenen Ergebnisse die Poisson Wahrscheinlichkeit für einen Sieg pro Team berechnet

            double[,] ResultStats = AverageGoalsPerGame(matchDataInHistory, match.Team1.TeamId, match.Team2.TeamId, LeagueShortCut); // Eine Funktion die die wahrscheinlichkeit für ein bestimmtes ergebniss berechnet            

            List<List<double>> resultStatsList = new List<List<double>>();

            for (int i = 0; i < ResultStats.GetLength(0); i++)
            {
                List<double> innerList = new List<double>();

                // Füge den Indexwert der Liste hinzu
                innerList.Add(i); // Hier wird der Indexwert (i) hinzugefügt

                for (int j = 0; j < ResultStats.GetLength(1); j++)
                {
                    innerList.Add(ResultStats[i, j]);
                }
                resultStatsList.Add(innerList);
            }

            List<List<string>> formattedResultStats = new List<List<string>>();

            foreach (var innerList in resultStatsList)
            {
                List<string> formattedInnerList = new List<string>();
                foreach (var value in innerList)
                {
                    formattedInnerList.Add(value.ToString("F4")); // Hier wird der Wert in einen String mit vier Nachkommastellen umgewandelt
                }
                formattedResultStats.Add(formattedInnerList);
            }
            PoissonResults = formattedResultStats;
        }

        public (int?,int?) DefineMatchResult(MatchData match)
        {
            PointsTeam1 = null;
            PointsTeam2 = null;

            List<MatchResult>? resultList = match.MatchResults;

            foreach (MatchResult result in resultList)
            {
                if(result.ResultTypeID == 2)
                {
                    PointsTeam1 = result.PointsTeam1;
                    PointsTeam2 = result.PointsTeam2;
                }
            }
        
            return (PointsTeam1, PointsTeam2);
        }

        // Hauptmethode, um die Anzahl der Siege und Unentschieden für die Teams zu berechnen
        public double[] CountWins(List<MatchData> matches, int PermanentTeam1Id, int PermanentTeam2Id, string LeagueShortcut)
        {           
            var (winTeam1, winTeam2, draw) = CalculateWinsAndDraws(matches, PermanentTeam1Id, PermanentTeam2Id, LeagueShortcut);
            double poissonTeam1Win = CalculatePoissonProbability(1, winTeam1);
            double poissonTeam2Win = CalculatePoissonProbability(1, winTeam2);
            double poissonDraw = CalculatePoissonProbability(1, draw);
            return new double[] { poissonTeam1Win, poissonTeam2Win, poissonDraw};
        }

        public double[,] AverageGoalsPerGame(List<MatchData> matches, int PermanentTeam1Id, int PermanentTeam2Id, string LeagueShortcut) // Diese Funktion berechnet die durchnitschlichen Tore pro Spiel die 2 Manschafften gegeneinander hatten.
        {
            var (AvgGoalsTeam1, AvgGoalsTeam2) = CalculateAverageGoals(matches, PermanentTeam1Id, PermanentTeam2Id, LeagueShortcut);
            double[,] PoissonProbsForResults = CalculatePoissonProbabilityForResult(AvgGoalsTeam1, AvgGoalsTeam2);
            return PoissonProbsForResults;
        }

        private (double, double) CalculateAverageGoals(List<MatchData> matches, int permanentTeam1Id, int permanentTeam2Id, string leagueShortcut)
        {
            double avgGoalsTeam1 = 0;
            double avgGoalsTeam2 = 0;
            int allGoalsTeam1 = 0;
            int allGoalsTeam2 = 0;

            foreach (MatchData match in matches)
            {
                var (calculateWithResults, calculateWithGoals) = CheckConditions(match);

                if (match.LeagueShortcut == leagueShortcut && calculateWithGoals == true)
                {
                    var (goalsTeam1, goalsTeam2) = CalculateGoals(match, permanentTeam1Id, permanentTeam2Id);

                    allGoalsTeam1 = allGoalsTeam1 + goalsTeam1;
                    allGoalsTeam2 = allGoalsTeam2 + goalsTeam2;                
                }
            }
            avgGoalsTeam1 = (double)allGoalsTeam1 / (double)matches.Count;
            avgGoalsTeam2 = (double)allGoalsTeam2 / (double)matches.Count;

            return (avgGoalsTeam1, avgGoalsTeam2);
        }

        //Methode zur Berechnung der Tore für die beiden Teams
        private (int, int) CalculateGoals(MatchData match, int permanentTeam1Id, int permanentTeam2Id)
        {
            int goalsTeam1 = 0;
            int goalsTeam2 = 0;
            int previousScoreTeam1 = 0;
            int previousScoreTeam2 = 0;

            foreach (Goal goal in match.Goals)
            {               
                int currentScoreTeam1 = 0;
                int currentScoreTeam2 = 0;            

                if (match.Team1.TeamId == permanentTeam1Id)
                {
                    currentScoreTeam1 = goal.ScoreTeam1 ?? 0;
                    currentScoreTeam2 = goal.ScoreTeam2 ?? 0;
                }
                else if (match.Team1.TeamId == permanentTeam2Id)
                {
                    currentScoreTeam1 = goal.ScoreTeam2 ?? 0;
                    currentScoreTeam2 = goal.ScoreTeam1 ?? 0;
                }

                if (currentScoreTeam1 > previousScoreTeam1)
                {
                    goalsTeam1++;
                }
                else if (currentScoreTeam2 > previousScoreTeam2)
                {
                    goalsTeam2++;
                }

                previousScoreTeam1 = currentScoreTeam1;
                previousScoreTeam2 = currentScoreTeam2;
            }
                                   
                return(goalsTeam1, goalsTeam2);
          
        }

        // Methode zur Berechnung der Anzahl der Siege und Unentschieden
        private (double, double, double) CalculateWinsAndDraws(List<MatchData> matches, int permanentTeam1Id, int permanentTeam2Id, string leagueShortcut)
        {
            int winsTeam1 = 0;
            int winsTeam2 = 0;
            int draws = 0;
 
            foreach (MatchData match in matches)
            {        

                var (calculateWithResults, calculateWithGoals) = CheckConditions(match);
              
                if (match.LeagueShortcut == leagueShortcut && calculateWithGoals == true)
                {

                    var (goalsTeam1, goalsTeam2) = CalculateGoals(match, permanentTeam1Id, permanentTeam2Id);

                    if (goalsTeam1 > goalsTeam2)
                    {
                        winsTeam1++;
                    }
                    else if (goalsTeam2 > goalsTeam1)
                    {
                        winsTeam2++;
                    }
                    else 
                    {                      
                        draws++;                                                               
                    }
                }
            }

            double team1Win = (double)winsTeam1 / (winsTeam1 + winsTeam2 + draws);
            double team2Win = (double)winsTeam2 / (winsTeam1 + winsTeam2 + draws);
            double draw = (double)draws / (winsTeam1 + winsTeam2 + draws);

            return (team1Win, team2Win, draw);
        }

        public List<MatchData> FindGamesInHistory(List<MatchData> matchhistory) 
        {
            // Find the Berlin time zone
            TimeZoneInfo berlinTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

            // Convert the current UTC time to Berlin time
            DateTime utcNow = DateTime.UtcNow;
            DateTime berlinTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, berlinTimeZone).Date;

            List<MatchData>matchDataInHistory = new List<MatchData>();
            foreach (MatchData match in matchhistory)
            {
                if (match.MatchDateTimeUTC.Value.Date < berlinTime) // Wenn das Match schon stattgefunden hat, dann ...
                {
                    matchDataInHistory.Add(match);
                }  
            } 

            return matchDataInHistory;
        }

        public double[,] CalculatePoissonProbabilityForResult(double lambda, double lambda2) // Berechnung der Poisson-Wahrscheinlichkeit für den Sieg einer Mannschaft
        {
            double[,] Probabilities = new double [4, 4];

            for (int k1 = 0; k1 < 4; k1++)
            { 
                for (int k2 = 0; k2 < 4; k2++)
                { 
                    double Faktor1 = CalculatePoissonProbability(k1, lambda);
                    double Faktor2 = CalculatePoissonProbability(k2, lambda2);
                    Probabilities[k1,k2] = Faktor1 * Faktor2;
                    Probabilities[k1,k2] = Probabilities[k1, k2] * 100;
                }
            }

            return Probabilities;
        }

        public double CalculatePoissonProbability(int k, double lambda) // Berechnung der Poisson-Wahrscheinlichkeit für ein bestimmtes Ergebniss.
        {
            double numerator = Math.Exp(-lambda) * Math.Pow(lambda, k);
            double denominator = Factorial(k);
            return numerator / denominator;
        }

        public double Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            double result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        private (bool, bool) CheckConditions(MatchData match)
        {
            bool calculateWithResult = false;
            bool calculateWithGoals = false;

            if (match.Goals.Count != 0 && match.MatchResults.Count != 0)
            {
                calculateWithGoals = true;
            }
            else if (match.Goals.Count != 0 && match.MatchResults.Count == 0)
            {
                calculateWithGoals = true;
            }
            else if (match.Goals.Count == 0 && match.MatchResults.Count != 0)
            {
                calculateWithResult = true;
            }

            return (calculateWithResult, calculateWithGoals);

        }
    }
}
