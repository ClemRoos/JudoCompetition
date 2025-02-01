using CompetitionJudo.Data.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.Data
{
    public class TableauDe8 : Tableau
    {
        public TableauDe8(List<Competiteur> grilleCompetiteurs)
        {
            this.grilleCompetiteurs = grilleCompetiteurs;
            this.sourceImage = Resources.ResizeTableau8;
            CreerCoordonnees();
        }
        public override void CreerFeuille()
        {
        }

        public override void CreerCoordonnees()
        {
            listeCoordonneesClub = new List<Coordonnee>();
            listeCoordonneesNom = new List<Coordonnee>();
            listeCoordonneesPrenom = new List<Coordonnee>();
            var n1 = new Coordonnee(30, 175);
            var n2 = new Coordonnee(30, 245);
            var n3 = new Coordonnee(30, 310);
            var n4 = new Coordonnee(30, 380);
            var n5 = new Coordonnee(660, 175);
            var n6 = new Coordonnee(660, 245);
            var n7 = new Coordonnee(660, 310);
            var n8 = new Coordonnee(660, 380);
            listeCoordonneesNom.Add(n1);
            listeCoordonneesNom.Add(n3);
            listeCoordonneesNom.Add(n5);
            listeCoordonneesNom.Add(n7);
            listeCoordonneesNom.Add(n2);
            listeCoordonneesNom.Add(n6);
            listeCoordonneesNom.Add(n4);
            listeCoordonneesNom.Add(n8);
            var p1 = new Coordonnee(30, 190);
            var p2 = new Coordonnee(30, 260);
            var p3 = new Coordonnee(30, 325);
            var p4 = new Coordonnee(30, 395);
            var p5 = new Coordonnee(660, 190);
            var p6 = new Coordonnee(660, 260);
            var p7 = new Coordonnee(660, 325);
            var p8 = new Coordonnee(660, 395);
            listeCoordonneesPrenom.Add(p1);
            listeCoordonneesPrenom.Add(p3);
            listeCoordonneesPrenom.Add(p5);
            listeCoordonneesPrenom.Add(p7);
            listeCoordonneesPrenom.Add(p2);
            listeCoordonneesPrenom.Add(p6);
            listeCoordonneesPrenom.Add(p4);
            listeCoordonneesPrenom.Add(p8);
            var c1 = new Coordonnee(30, 205);
            var c2 = new Coordonnee(30, 275);
            var c3 = new Coordonnee(30, 340);
            var c4 = new Coordonnee(30, 410);
            var c5 = new Coordonnee(660, 205);
            var c6 = new Coordonnee(660, 275);
            var c7 = new Coordonnee(660, 340);
            var c8 = new Coordonnee(660, 410);
            listeCoordonneesClub.Add(c1);
            listeCoordonneesClub.Add(c3);
            listeCoordonneesClub.Add(c5);
            listeCoordonneesClub.Add(c7);
            listeCoordonneesClub.Add(c2);
            listeCoordonneesClub.Add(c6);
            listeCoordonneesClub.Add(c4);
            listeCoordonneesClub.Add(c8);
        }
        
    }
}
