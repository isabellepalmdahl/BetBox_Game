using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using supX.ViewModels;

namespace supX.Models
{
    public class GameEngineModel
    {
        #region Variables
        public string filename = new Uri(@".\Assets\Json\fighters.json", UriKind.Relative).ToString();
        public FighterViewModel fighter;
        private FighterViewModel fighterViewModel;
        #endregion

        #region Properties
        public double[] Odds { get; set; }
        public FighterViewModel Fighter1 { get; set; }
        public FighterViewModel Fighter2 { get; set; }
        public MainViewModel Parent { get; }
        private PlayerViewModel PlayerVM { get; set; }
        public double BetAmount { get; set; }
        private double BetOdds { get; set; }
        #endregion

        #region Constructors
        public GameEngineModel()
        {
            fighterViewModel = new FighterViewModel();
            OpenFile();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Opens Json files
        /// </summary>
        private void OpenFile()
        {
            fighter = FileHandler.FileHandler.Open<FighterViewModel>(filename);
        }

        /// <summary>
        /// Method that randomly selects two fighters from the fighter list
        /// </summary>
        /// <param name="fighters"></param>
        /// <returns>2 fighterIDs</returns>
        private int[] GenerateFight(List<FighterViewModel> fighters)
        {
            int fighterCount = fighters.Count;
            int[] fighterIDs = new int[2];

            Random random = new Random();

            fighterIDs[0] = random.Next(0, fighterCount);
            do
            {
                fighterIDs[1] = random.Next(0, fighterCount);
            } while (fighterIDs[0] == fighterIDs[1]);

            return fighterIDs;
        }

        /// <summary>
        /// Method that is used to generate odds 
        /// </summary>
        /// <param name="fighter1"></param>
        /// <param name="fighter2"></param>
        /// <returns>an array with odds for 2 fighters</returns>
        private double[] GenerateOdds(FighterViewModel fighter1, FighterViewModel fighter2)
        {
            double[] oddsArray = new double[2];
            double winChangePercentage = 50;

            winChangePercentage += (fighter1.Strength - fighter2.Defense) * 5;
            winChangePercentage += (fighter1.Speed - fighter2.Strength) * 3;
            winChangePercentage += (fighter1.Cardio - fighter2.Cardio) * 1;

            oddsArray[0] = Math.Round(0.95 / (winChangePercentage / 100), 2);
            oddsArray[1] = Math.Round(0.95 / ((100 - winChangePercentage) / 100), 2);

            return oddsArray;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Method to generate fighters with odds for one arena
        /// </summary>
        public void GenerateArena()
        {
            int[] fighterArray = GenerateFight(fighter.fighters);
            Odds = GenerateOdds(fighter.fighters[fighterArray[0]], fighter.fighters[fighterArray[1]]);
            Fighter1 = fighter.fighters[fighterArray[0]];
            Fighter2 = fighter.fighters[fighterArray[1]];
        }

        /// <summary>
        /// Method used to set bet on a specific fighter. Also ensures that the bet is bigger than 0 and that one bet has been made.
        /// </summary>
        /// <param name="BetAmount1"></param>
        /// <param name="BetAmount2"></param>
        /// <param name="FighterId1"></param>
        /// <param name="FighterId2"></param>
        /// <returns>BetID</returns>
        public int SetMyBet(double BetAmount1, double BetAmount2, int FighterId1, int FighterId2)
        {
            int MyBetId = 0;
            if (BetAmount1 <= 0 && BetAmount2 <= 0)
            {
                MessageBox.Show("You have to bet on someone, you idiot!");
                Parent.CurrentViewModel = new BettingViewBellagioViewModel(null);
            }
            else if (BetAmount1 > 0)
            {
                MyBetId = FighterId1;
            }
            else
            {
                MyBetId = FighterId2;
            }
            return MyBetId;
        }


        /// <summary>
        /// Method that calculates the winning amount
        /// </summary>
        /// <param name="myBet"></param>
        /// <param name="winner"></param>
        /// <param name="myBalance"></param>
        /// <returns>WinnerAmount</returns>
        public double WinnerAmount (FighterViewModel myBet, FightViewModel winner, double myBalance)
        {
            double betAmount = BetAmount;
            double odds = winner.WinnerOdds;
            double winnerAmount;
            bool result = GenerateBetResult(myBet, winner);

            winnerAmount = betAmount * odds - betAmount;
            return Math.Round(winnerAmount);
        }

        /// <summary>
        /// Method that calculates new balance after fight
        /// </summary>
        /// <param name="myBet"></param>
        /// <param name="winner"></param>
        /// <param name="myBalance"></param>
        /// <returns>New balance</returns>
        public double CalculateNewBalance(FighterViewModel myBet, FightViewModel winner, double myBalance)
        {
            double betAmount = BetAmount;
            double odds = winner.WinnerOdds;
            bool result = GenerateBetResult(myBet, winner);

            if (result == false)
            {
                myBalance = myBalance - betAmount;
                return Math.Round(myBalance);
            }
            else
            {
                myBalance = myBalance - betAmount;
                myBalance = (betAmount * odds) + myBalance;
                return Math.Round(myBalance);
            }
        }

        /// <summary>
        /// Method that sets the betAmount 
        /// </summary>
        /// <param name="betamount1"></param>
        /// <param name="betamount2"></param>
        /// <returns>betAmount</returns>
        public double SetBetAmount(double betamount1, double betamount2)
        {
            double betamount;
            if (betamount1 > 0)
            {
                betamount = betamount1;
            }
            else
            {
                betamount = betamount2;
            }
            return betamount;

        }


        /// <summary>
        /// Method that generate the result of the fight
        /// </summary>
        /// <param name="fighter1"></param>
        /// <param name="fighter2"></param>
        /// <returns>Winner</returns>
        public FightViewModel GenerateResult(FighterViewModel fighter1, FighterViewModel fighter2)
        {
            Random random = new Random();

            int typeOfFinish = random.Next(1, 4);
            int roundsToFinish;
            int winChance = 100;
            FightViewModel winner = new FightViewModel();

            // 1 in 3 chance the fight goes to decision.
            if (typeOfFinish != 3)
            {
                roundsToFinish = random.Next(1, 12);
            }
            else
            {
                roundsToFinish = 12;
            }
            // If the fight goes to desicion (12 rounds), every point in cardio adds 10% win chance and every point in speed adds 5%.
            if (roundsToFinish == 12)
            {
                winChance += (fighter1.Cardio * 20) - (fighter2.Cardio * 20);
                winChance += (fighter1.Speed * 10) - (fighter2.Speed * 10);
                winner.NumberOfRounds = 12;
            }
            // Else if the fight end in a KO or TKO; strength, speed and defense gives an edge.
            else
            {
                winChance += (fighter1.Strength * 20) - (fighter2.Strength * 20);
                winChance += (fighter1.Speed * 5) - (fighter2.Speed * 5);
                winChance += (fighter1.Defense * 20) - (fighter2.Defense * 20);
                // For every round it takes to finish the fight, additional win chance is added based on cardio.
                for (int i = 0; i < roundsToFinish; i++)
                {
                    winChance += (fighter1.Cardio * 2) - (fighter2.Cardio * 2);
                }
                winner.NumberOfRounds = roundsToFinish;
            }

            int win = random.Next(1, 100);

            if (win <= (winChance / 2))
            {
                winner.WinnerId = fighter1.Id;
                winner.WinnerName = fighter1.Name;
                winner.LoserName = fighter2.Name;
                winner.WinnerOdds = Odds[0];
            }
            else
            {
                winner.WinnerId = fighter2.Id;
                winner.WinnerName = fighter2.Name;
                winner.LoserName = fighter1.Name;
                winner.WinnerOdds = Odds[1];
            }

            return winner;

        }

        /// <summary>
        /// Method that generates the bet result
        /// </summary>
        /// <param name="myBet"></param>
        /// <param name="winner"></param>
        /// <returns>Won or lost</returns>
        public bool GenerateBetResult(FighterViewModel myBet, FightViewModel winner)
        {
            if (myBet.Id == winner.WinnerId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
