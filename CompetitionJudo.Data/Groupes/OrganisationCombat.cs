﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CompetitionJudo.Data
{
    public abstract class OrganisationCombat
    {
        public OrganisationCombat()
        {
            CoordonneesNomCompetition = new PointF(320, 20);
            CoordonneesPoidsGroupe = new PointF(320, 40);
            CoordonneesTempsCombat = new PointF(20, 20);
            CoordonneesTempsImmobilisationIppon = new PointF(20, 40);
        }

        public List<Competiteur> grilleCompetiteurs { get; set; }
        public double poidsMini { get; set; }
        public double poidsMaxi { get; set; }
        public int numeroGroupe { get; set; }
        public string genre { get; set; }
        public Bitmap sourceImage { get; set; }
        public List<Coordonnee> listeCoordonneesNom { get; set; }
        public List<Coordonnee> listeCoordonneesPrenom { get; set; }
        public List<Coordonnee> listeCoordonneesClub { get; set; }  

        public PointF CoordonneesNomCompetition { get; set; }
        public PointF CoordonneesPoidsGroupe { get; set; }
        public PointF CoordonneesTempsCombat { get; set; }
        public PointF CoordonneesTempsImmobilisationIppon { get; set; }
        public PointF CoordonneesTempsImmobilisationWazaari { get; set; }


        public abstract void CreerFeuille();

        //Créer les coordonnées des nom+prenom+clubs qui seront affichés sur les feuilles imprimées
        public abstract void CreerCoordonnees();
    }
}
