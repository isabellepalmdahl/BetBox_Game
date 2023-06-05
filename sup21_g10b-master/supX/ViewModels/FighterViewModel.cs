using System;
using System.Collections.Generic;
using System.Text;

namespace supX.ViewModels
{ public class FighterViewModel : BaseViewModel
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Cardio { get; set; }
        public int Speed { get; set; }
        public int Defense { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string ImagePath { get; set; }
        public List<FighterViewModel> fighters { get; set; }
        #endregion

        #region Constructors
        public FighterViewModel()
        {
            fighters = new List<FighterViewModel>();
        }
        #endregion
    }

}
