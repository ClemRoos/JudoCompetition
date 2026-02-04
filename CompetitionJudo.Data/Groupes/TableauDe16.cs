using CompetitionJudo.Data.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompetitionJudo.Data
{
    public class TableauDe16 : Tableau
    {
        public TableauDe16(List<Competiteur> grilleCompetiteurs)
        {
            this.grilleCompetiteurs = grilleCompetiteurs;
            this.sourceImage = Resources.ResizeTableau16;
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
            var n1 = new Coordonnee(27, 65);
            var n2 = new Coordonnee(27, 115);
            var n3 = new Coordonnee(27, 170);
            var n4 = new Coordonnee(27, 222);
            var n5 = new Coordonnee(27, 302);
            var n6 = new Coordonnee(27, 357);
            var n7 = new Coordonnee(27, 408);
            var n8 = new Coordonnee(27, 460);
            var n9 = new Coordonnee(667, 65);
            var n10 = new Coordonnee(667, 117);
            var n11 = new Coordonnee(667, 170);
            var n12 = new Coordonnee(667, 222);
            var n13 = new Coordonnee(667, 303);
            var n14 = new Coordonnee(667, 357);
            var n15 = new Coordonnee(667, 410);
            var n16 = new Coordonnee(667, 462);
            listeCoordonneesNom.Add(n1);
            listeCoordonneesNom.Add(n2);
            listeCoordonneesNom.Add(n3);
            listeCoordonneesNom.Add(n4);
            listeCoordonneesNom.Add(n5);
            listeCoordonneesNom.Add(n6);
            listeCoordonneesNom.Add(n7);
            listeCoordonneesNom.Add(n8);
            listeCoordonneesNom.Add(n9);
            listeCoordonneesNom.Add(n10);
            listeCoordonneesNom.Add(n11);
            listeCoordonneesNom.Add(n12);
            listeCoordonneesNom.Add(n13);
            listeCoordonneesNom.Add(n14);
            listeCoordonneesNom.Add(n15);
            listeCoordonneesNom.Add(n16);
            var p1 = new Coordonnee(27, 80);
            var p2 = new Coordonnee(27, 130);
            var p3 = new Coordonnee(27, 185);
            var p4 = new Coordonnee(27, 238);
            var p5 = new Coordonnee(27, 317);
            var p6 = new Coordonnee(27, 372);
            var p7 = new Coordonnee(27, 423);
            var p8 = new Coordonnee(27, 475);
            var p9 = new Coordonnee(667, 80);
            var p10 = new Coordonnee(667, 132);
            var p11 = new Coordonnee(667, 185);
            var p12 = new Coordonnee(667, 238);
            var p13 = new Coordonnee(667, 318);
            var p14 = new Coordonnee(667, 372);
            var p15 = new Coordonnee(667, 425);
            var p16 = new Coordonnee(667, 477);
            listeCoordonneesPrenom.Add(p1);
            listeCoordonneesPrenom.Add(p2);
            listeCoordonneesPrenom.Add(p3);
            listeCoordonneesPrenom.Add(p4);
            listeCoordonneesPrenom.Add(p5);
            listeCoordonneesPrenom.Add(p6);
            listeCoordonneesPrenom.Add(p7);
            listeCoordonneesPrenom.Add(p8);
            listeCoordonneesPrenom.Add(p9);
            listeCoordonneesPrenom.Add(p10);
            listeCoordonneesPrenom.Add(p11);
            listeCoordonneesPrenom.Add(p12);
            listeCoordonneesPrenom.Add(p13);
            listeCoordonneesPrenom.Add(p14);
            listeCoordonneesPrenom.Add(p15);
            listeCoordonneesPrenom.Add(p16);
            var c1 = new Coordonnee(27, 95);
            var c2 = new Coordonnee(27, 145);
            var c3 = new Coordonnee(27, 200);
            var c4 = new Coordonnee(27, 253);
            var c5 = new Coordonnee(27, 332);
            var c6 = new Coordonnee(27, 387);
            var c7 = new Coordonnee(27, 438);
            var c8 = new Coordonnee(27, 490);
            var c9 = new Coordonnee(667, 95);
            var c10 = new Coordonnee(667, 147);
            var c11 = new Coordonnee(667, 200);
            var c12 = new Coordonnee(667, 253);
            var c13 = new Coordonnee(667, 333);
            var c14 = new Coordonnee(667, 387);
            var c15 = new Coordonnee(667, 440);
            var c16 = new Coordonnee(667, 492);
            listeCoordonneesClub.Add(c1);
            listeCoordonneesClub.Add(c2);
            listeCoordonneesClub.Add(c3);
            listeCoordonneesClub.Add(c4);
            listeCoordonneesClub.Add(c5);
            listeCoordonneesClub.Add(c6);
            listeCoordonneesClub.Add(c7);
            listeCoordonneesClub.Add(c8);
            listeCoordonneesClub.Add(c9);
            listeCoordonneesClub.Add(c10);
            listeCoordonneesClub.Add(c11);
            listeCoordonneesClub.Add(c12);
            listeCoordonneesClub.Add(c13);
            listeCoordonneesClub.Add(c14);
            listeCoordonneesClub.Add(c15);
            listeCoordonneesClub.Add(c16);
        }
    }
}
