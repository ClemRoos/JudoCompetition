using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Drawing.Printing;
using System.Drawing;
using CompetitionJudo.Data;
using CompetitionJudo.UI.ViewModel;
using Microsoft.Win32;

namespace CompetitionJudo.UI
{

    public partial class FenetreImpression : Window
    {
        #region Private Properties

        FenetreImpressionViewModel VM;
        List<Competiteur> actualSelected = new List<Competiteur>();

        private float ParametreEchelleWindows { get; set; }

        private const string TempsCombat = "Temps Combat : {0}m{1}s";
        private const string DefinitionPoule = "{0} : poule n°{1} de {2}kg à {3}kg";
        private const string TempsImmobilisationIppon = "Temps Immobilisation Ippon : {0}s";
        private const string TempsImmobilisationWazaAri = "Temps Immobilisation Waza Ari : {0}s";
        private const string NomDateCompetition = "{0} - {1}";

        #endregion

        #region Style

        private Font drawFont = new Font("Arial", 9);
        private SolidBrush drawBrush = new SolidBrush(Color.Black);

        #endregion

        public FenetreImpression(List<Groupe> lesGroupes, string nomCompetition, DateTime dateCompetition)
        {
            InitializeComponent();

            VM = new FenetreImpressionViewModel();
            this.DataContext = VM;
            VM.DateCompetition = dateCompetition;
            VM.NomCompetition = nomCompetition;
            VM.LesGroupes = lesGroupes;
            VM.ElementsAImprimer = VM.LesGroupes.Count();

            lesGroupes.Sort((a, b) => String.Compare(a.id.ToString(), b.id.ToString()));

            actualSelected = lesGroupes.ElementAt(0).Competiteurs;
            ComboBoxListeGroupes.SelectedValue = lesGroupes.ElementAt(0);
            ComboBoxListeGroupes.DataContext = lesGroupes;
            tableauCompetiteurs.DataContext = actualSelected;
        }

        private Single InitiliseParametreEchelleWindows(int echelleImpression)
        {
            //var scaleValue = Convert.ToInt16(Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ThemeManager", "LastLoadedDPI", "120"));
            switch (echelleImpression)
            {
                case 100:
                    return 0.5f;
                case 125:
                    return 0.833333f;
                case 150:
                    return 1.25f;
                case 175:
                    return 1.5f;
                default:
                    return 0.833333f;
            }
        }

        private void ListeGroupes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as System.Windows.Controls.ComboBox;

            foreach (var groupe in VM.LesGroupes)
            {
                if (groupe.id.ToString().Equals(comboBox.SelectedItem.ToString()))
                {
                    actualSelected = groupe.Competiteurs;
                    tableauCompetiteurs.DataContext = actualSelected;
                    if (groupe.TypeGroupe == TypeGroupe.Poule)
                    {
                        estUnePoule();
                    }
                    else
                    {
                        estUnTableau();
                    }
                }
            }
        }

        private void estUnePoule()
        {
            LabelTableau.TextDecorations = TextDecorations.Strikethrough;
            LabelPoule.TextDecorations = null;
        }

        private void estUnTableau()
        {
            LabelPoule.TextDecorations = TextDecorations.Strikethrough;
            LabelTableau.TextDecorations = null;
        }

        private void BoutonPouleToTableau_Click(object sender, RoutedEventArgs e)
        {
            foreach (var groupe in VM.LesGroupes)
            {
                if (groupe.id.ToString().Equals(ComboBoxListeGroupes.Text))
                {
                    if (groupe.TypeGroupe == TypeGroupe.Poule)
                    {
                        estUnTableau();
                        groupe.TypeGroupe = TypeGroupe.Tableau;
                    }
                    else
                    {
                        estUnePoule();
                        groupe.TypeGroupe = TypeGroupe.Poule;
                    }
                }
            }
        }

        private void pd_PrintPageSoloPage(object sender, PrintPageEventArgs ev)
        {
            Graphics graphic = ev.Graphics;

            var ig = new ImageGroupe(VM.LesGroupes.First(c => c.id.ToString().Equals(ComboBoxListeGroupes.Text)));
            var poidsMin = ig.Organisation.grilleCompetiteurs.Min(c => c.Poids);
            var poidsMax = ig.Organisation.grilleCompetiteurs.Max(c => c.Poids);
            ParametreEchelleWindows = InitiliseParametreEchelleWindows(ig.Groupe.EchelleImpression);

            graphic.DrawImage(ig.imageGroupe, 1, 1, ig.imageGroupe.Width * ParametreEchelleWindows, ig.imageGroupe.Height * ParametreEchelleWindows);

            graphic.DrawString(string.Format(NomDateCompetition, VM.NomCompetition.ToString(), String.Format("{0:d MMMM yyyy}", VM.DateCompetition)), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesNomCompetition.X, ig.Organisation.CoordonneesNomCompetition.Y));
            graphic.DrawString(string.Format(DefinitionPoule, ig.Groupe.Categorie, ig.Organisation.grilleCompetiteurs[0].Poule.ToString(), poidsMin, poidsMax), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesPoidsGroupe.X, ig.Organisation.CoordonneesPoidsGroupe.Y));
            graphic.DrawString(string.Format(TempsCombat, ig.Groupe.TempsCombat.TimeSinceLastEvent.Minutes, ig.Groupe.TempsCombat.TimeSinceLastEvent.Seconds), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesTempsCombat.X, ig.Organisation.CoordonneesTempsCombat.Y));
            graphic.DrawString(string.Format(TempsImmobilisationIppon, ig.Groupe.TempsImmo.TimeSinceLastEvent.Seconds), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesTempsImmobilisationIppon.X, ig.Organisation.CoordonneesTempsImmobilisationIppon.Y));

            for (int i = 0; i < ig.Organisation.grilleCompetiteurs.Count; i++)
            {
                var cdn = ig.Organisation.listeCoordonneesNom[i];
                graphic.DrawString(ig.Organisation.grilleCompetiteurs[i].Nom, drawFont, drawBrush, new PointF(cdn.x, cdn.y));
                cdn = ig.Organisation.listeCoordonneesPrenom[i];
                graphic.DrawString(ig.Organisation.grilleCompetiteurs[i].Prenom, drawFont, drawBrush, new PointF(cdn.x, cdn.y));
                cdn = ig.Organisation.listeCoordonneesClub[i];
                graphic.DrawString(ig.Organisation.grilleCompetiteurs[i].Club, drawFont, drawBrush, new PointF(cdn.x, cdn.y));
            }
        }

        public void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            //ParametreEchelleWindows = 0.833333f;

            Graphics graphic = ev.Graphics;

            var ig = new ImageGroupe(VM.LesGroupes.ElementAt(VM.LesGroupes.Count() - VM.ElementsAImprimer));
            var poidsMinG1 = ig.Organisation.grilleCompetiteurs.Min(c => c.Poids);
            var poidsMaxG1 = ig.Organisation.grilleCompetiteurs.Max(c => c.Poids);
            ParametreEchelleWindows = InitiliseParametreEchelleWindows(ig.Groupe.EchelleImpression);

            //System.Drawing.Point ulCorner = new System.Drawing.Point(1, 1);
            graphic.DrawImage(ig.imageGroupe, 1, 1, ig.imageGroupe.Width * ParametreEchelleWindows, ig.imageGroupe.Height * ParametreEchelleWindows);

            //graphic.DrawImage(ig.imageGroupe, ulCorner);

            graphic.DrawString(string.Format(NomDateCompetition, VM.NomCompetition.ToString(), String.Format("{0:d MMMM yyyy}", VM.DateCompetition)), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesNomCompetition.X, ig.Organisation.CoordonneesNomCompetition.Y));
            graphic.DrawString(string.Format(DefinitionPoule, ig.Groupe.Categorie, ig.Organisation.grilleCompetiteurs[0].Poule.ToString(), poidsMinG1, poidsMaxG1), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesPoidsGroupe.X, ig.Organisation.CoordonneesPoidsGroupe.Y));
            graphic.DrawString(string.Format(TempsCombat, ig.Groupe.TempsCombat.TimeSinceLastEvent.Minutes, ig.Groupe.TempsCombat.TimeSinceLastEvent.Seconds), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesTempsCombat.X, ig.Organisation.CoordonneesTempsCombat.Y));
            graphic.DrawString(string.Format(TempsImmobilisationIppon, ig.Groupe.TempsImmo.TimeSinceLastEvent.Seconds), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesTempsImmobilisationIppon.X, ig.Organisation.CoordonneesTempsImmobilisationIppon.Y));

            for (int i = 0; i < ig.Organisation.grilleCompetiteurs.Count; i++)
            {
                var cdn = ig.Organisation.listeCoordonneesNom[i];
                graphic.DrawString(ig.Organisation.grilleCompetiteurs[i].Nom, drawFont, drawBrush, new PointF(cdn.x, cdn.y));
                cdn = ig.Organisation.listeCoordonneesPrenom[i];
                graphic.DrawString(ig.Organisation.grilleCompetiteurs[i].Prenom, drawFont, drawBrush, new PointF(cdn.x, cdn.y));
                cdn = ig.Organisation.listeCoordonneesClub[i];
                graphic.DrawString(ig.Organisation.grilleCompetiteurs[i].Club, drawFont, drawBrush, new PointF(cdn.x, cdn.y));
            }

            if (!(VM.ElementsAImprimer == 1 && VM.LesGroupes.Count() % 2 == 1))
            {
                var ig2 = new ImageGroupe(VM.LesGroupes.ElementAt(VM.LesGroupes.Count() - VM.ElementsAImprimer + 1));
                var poidsMinG2 = ig2.Organisation.grilleCompetiteurs.Min(c => c.Poids);
                var poidsMaxG2 = ig2.Organisation.grilleCompetiteurs.Max(c => c.Poids);

                graphic.DrawImage(ig2.imageGroupe, 1, 585, ig2.imageGroupe.Width * ParametreEchelleWindows, ig2.imageGroupe.Height * ParametreEchelleWindows);

                graphic.DrawString(string.Format(NomDateCompetition, VM.NomCompetition.ToString(), String.Format("{0:d MMMM yyyy}", VM.DateCompetition)), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesNomCompetition.X, ig.Organisation.CoordonneesNomCompetition.Y+585));
                graphic.DrawString(string.Format(DefinitionPoule, ig2.Groupe.Categorie, ig2.Organisation.grilleCompetiteurs[0].Poule.ToString(), poidsMinG2, poidsMaxG2), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesPoidsGroupe.X, ig.Organisation.CoordonneesPoidsGroupe.Y+585));
                graphic.DrawString(string.Format(TempsCombat, ig2.Groupe.TempsCombat.TimeSinceLastEvent.Minutes, ig2.Groupe.TempsCombat.TimeSinceLastEvent.Seconds), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesTempsCombat.X, ig.Organisation.CoordonneesTempsCombat.Y+585));
                graphic.DrawString(string.Format(TempsImmobilisationIppon, ig2.Groupe.TempsImmo.TimeSinceLastEvent.Seconds), drawFont, drawBrush, new PointF(ig.Organisation.CoordonneesTempsImmobilisationIppon.X, ig.Organisation.CoordonneesTempsImmobilisationIppon.Y+585));

                for (int i = 0; i < ig2.Organisation.grilleCompetiteurs.Count; i++)
                {
                    var cdn = ig2.Organisation.listeCoordonneesNom[i];
                    graphic.DrawString(ig2.Organisation.grilleCompetiteurs[i].Nom, drawFont, drawBrush, new PointF(cdn.x, (cdn.y + 585)));
                    cdn = ig2.Organisation.listeCoordonneesPrenom[i];
                    graphic.DrawString(ig2.Organisation.grilleCompetiteurs[i].Prenom, drawFont, drawBrush, new PointF(cdn.x, (cdn.y + 585)));
                    cdn = ig2.Organisation.listeCoordonneesClub[i];
                    graphic.DrawString(ig2.Organisation.grilleCompetiteurs[i].Club, drawFont, drawBrush, new PointF(cdn.x, (cdn.y + 585)));
                }
            }

            if (VM.ElementsAImprimer <= 2)
            {
                ev.HasMorePages = false;
            }
            else
            {
                ev.HasMorePages = true;
                VM.ElementsAImprimer -= 2;
            }
        }

        private void BoutonImprimerUnSeulGroupe_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPageSoloPage);
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BoutonImprimerTousLesGroupes_Click(object sender, RoutedEventArgs e)
        {

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }
    }
}
