using CompetitionJudo.Business.File_Import;
using CompetitionJudo.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionJudo.UI.ViewModel
{
    public class FenetreImportCompetiteursViewModel : BaseViewModel
    {
        private List<Competiteur> listeNouveauxCompetiteur;
        public string cheminFichier { get; set; }
        public Action<Competiteur> action;

        public FenetreImportCompetiteursViewModel(string cheminFichier, Action<Competiteur> action)
        {
            this.cheminFichier = cheminFichier;
            this.action = action;
            listeNouveauxCompetiteur = new List<Competiteur>();
        }

        public List<Competiteur> ListeNouveauxCompetiteur
        {
            get
            {
                return listeNouveauxCompetiteur;
            }
            set
            {
                listeNouveauxCompetiteur = value;
                OnPropertyChanged("ListeNouveauxCompetiteur");
            }
        }

        public async void ImporterFichier()
        {
            ExcelImport ExcelImport = new ExcelImport();
            if (cheminFichier.Contains(".csv"))
            {
                ListeNouveauxCompetiteur = await ExcelImport.ImporterCSV(cheminFichier);
            }
            if (cheminFichier.Contains(".xls"))
            {
                ListeNouveauxCompetiteur = ExcelImport.ImporterXLS(cheminFichier);
            }

            OnPropertyChanged("ListeNouveauxCompetiteur");
        }

    }
}
