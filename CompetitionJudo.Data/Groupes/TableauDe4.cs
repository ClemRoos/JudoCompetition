﻿using CompetitionJudo.Data.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.Data
{
    public class TableauDe4 : Tableau
    {
        public TableauDe4(List<Competiteur> grilleCompetiteurs)
        {
            this.grilleCompetiteurs = grilleCompetiteurs;
            this.sourceImage = Resources.ResizeTableau4;
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
            var n1 = new Coordonnee(50, 165);
            var n2 = new Coordonnee(50, 235);
            var n3 = new Coordonnee(50, 300);
            var n4 = new Coordonnee(50, 370);
            listeCoordonneesNom.Add(n1);
            listeCoordonneesNom.Add(n2);
            listeCoordonneesNom.Add(n3);
            listeCoordonneesNom.Add(n4);
            var p1 = new Coordonnee(50, 180);
            var p2 = new Coordonnee(50, 250);
            var p3 = new Coordonnee(50, 315);
            var p4 = new Coordonnee(50, 385);
            listeCoordonneesPrenom.Add(p1);
            listeCoordonneesPrenom.Add(p2);
            listeCoordonneesPrenom.Add(p3);
            listeCoordonneesPrenom.Add(p4);
            var cl1 = new Coordonnee(50, 195);
            var cl2 = new Coordonnee(50, 265);
            var cl3 = new Coordonnee(50, 330);
            var cl4 = new Coordonnee(50, 400);
            listeCoordonneesClub.Add(cl1);
            listeCoordonneesClub.Add(cl2);
            listeCoordonneesClub.Add(cl3);
            listeCoordonneesClub.Add(cl4);
        }
    }
}
