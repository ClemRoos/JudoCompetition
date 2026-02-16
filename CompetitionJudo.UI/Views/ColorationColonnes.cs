using CompetitionJudo.Data;
using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Linq;
using System.Globalization;

namespace CompetitionJudo.UI
{
    public class ColorationColonnesCompetiteurs : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Competiteur input = value as Competiteur;
            if (input.IndexGroupe % 2 != 0)
            {
                return "#A1C9FF";
            }
            else
            {
                return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorationColonnesGroupes : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Groupe groupe = value as Groupe;

            string lineColor = "#ffffff";

            if (groupe != null)
            {
                groupe.Commentaire = string.Empty;
                
                if (groupe.CompositionGroupe == Sexes.Mixte)
                {
                    groupe.Commentaire = "Mixte." + groupe.Commentaire;
                    lineColor = "#FCBD00";
                }           
                if (groupe.Competiteurs.Count > 1)
                {
                    if (groupe.Competiteurs.Select(c => c.Club).Distinct().Count() != groupe.Competiteurs.Count())
                    {
                        groupe.Commentaire = "+1 même club par poule."+ groupe.Commentaire;
                        lineColor = "#FCBD00";
                    }
                    if (groupe.PoidsMax > ((groupe.PoidsMin) + (10 * groupe.PoidsMin / 100)))
                    {
                        if (groupe.PoidsMax > ((groupe.PoidsMin) + (20 * groupe.PoidsMin / 100)))
                        {
                            groupe.Commentaire = "20% différence poids."+ groupe.Commentaire;
                             lineColor = "#E86E00";
                        }
                        else
                        {
                            groupe.Commentaire = "10% différence poids."+ groupe.Commentaire;
                            lineColor = "#FCBD00";
                        }                        
                    }                    
                }
                if (groupe.Competiteurs.Count <= 1)
                {
                    groupe.Commentaire = "1 seul compétiteur."+ groupe.Commentaire;
                    lineColor = "#DB372D";
                }
            }
            return lineColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
