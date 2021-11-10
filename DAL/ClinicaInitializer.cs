using System;
using ClinicaDentalArt.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace ClinicaDentalArt.DAL
{
    public class ClinicaInitializer : DropCreateDatabaseIfModelChanges<ClinicaContext>
    {
        protected override void Seed(ClinicaContext context)
        {
            var programari = new List<Programare>
 {
 
 new Programare{Nume="Ionescu",Prenume="Ion", Tratament="Detartraj", Telefon="0700111222", Data=DateTime.Parse("2021-11-15"), Email="ion@exemplu.ro", EchipaID=1, Comment="control rutina", Tags=" "},
 new Programare{Nume="Popescu",Prenume="Ionut", Tratament="Consultatie", Telefon="0711222333", Data=DateTime.Parse("2021-11-16"), Email="ionut@exemplu.ro", EchipaID=2, Comment="durere la rece", Tags=" "},
 new Programare{Nume="Popa",Prenume="Elena", Tratament="Detartraj", Telefon="0722333444", Data=DateTime.Parse("2021-11-17"), Email="elena@exemplu.ro", EchipaID=1, Comment="sangerare gingii", Tags=" "},
 new Programare{Nume="Ilie",Prenume="Ilie", Tratament="Consultatie", Telefon="0733444999", Data=DateTime.Parse("2021-11-18"), Email="ilie@exemplu.ro", EchipaID=2, Comment="durere cand mananc", Tags=" "},
 new Programare{Nume="Florea",Prenume="Ion", Tratament="Extractie", Telefon="0766444666", Data=DateTime.Parse("2021-11-19"), Email="ion@exemplu.ro", EchipaID=3, Comment="durere permanenta", Tags=" "},
 new Programare{Nume="Popa",Prenume="Marin", Tratament="Consultatie", Telefon="0744777555", Data=DateTime.Parse("2021-11-22"), Email="marin@exemplu.ro", EchipaID=2, Comment="durere masea", Tags=" "},
 new Programare{Nume="Ionescu",Prenume="Elena", Tratament="Consultatie", Telefon="0700123000", Data=DateTime.Parse("2021-11-23"), Email="elenai@exemplu.ro", EchipaID=1, Comment="sangerare la periaj", Tags=" "}

 };
            programari.ForEach(s => context.Programari.Add(s));
            context.SaveChanges();

            var servicii = new List<Serviciu>
 {
 new Serviciu{Nume="Consultatie", Info="Cunoasterea nevoilor pacientului, plan de tratament."},
 new Serviciu{Nume="Urgente", Info = "Extractii dentare, drenajul abceselor, pansamente, etc."},
 new Serviciu{Nume="Terapie Dentara", Info = "Tratamentul cariilor și al durerilor dentare."},
 new Serviciu{Nume="Tratament de canal", Info = "Tratarea chemo-mecanica a canalelor radiculare."},
 new Serviciu{Nume="Tratament parodontal", Info = "Dinti rezistenti si gingii sanatoase."},
 new Serviciu{Nume="Detartraj cu Ultrasunete", Info = "Pastreaza dantura sanatoasa."},
 new Serviciu{Nume="Coroane dentare", Info = "Calitate si durabilitate."},
 new Serviciu{Nume="Fatete Dentare", Info = "Zambet ca la Hollywood"},
 new Serviciu{Nume="Proteze Dentare", Info = "Zambeste din nou cu incredere!"},
 new Serviciu{Nume="Punti Dentare", Info = "Pentru unul sau mai multi dinti lipsa."},
 new Serviciu{Nume="Implant Dentar", Info = "Pentru o calitate mai buna a vietii."},
 new Serviciu{Nume="Tratament Laser", Info = "Tratamente minim-invazive cu laserul, cu actiune locala."},
 new Serviciu{Nume="Chirurgie Orala", Info = "Rezolvarea complicatiilor dentare."},
 new Serviciu{Nume="Albire Dentara Profesionala", Info = "Dinti mai albi cu cateva nuante."},
 new Serviciu{Nume="Stomatologie Copii", Info = "Tot ce e mai bun pentru copilul tau."}

 };
            servicii.ForEach(s => context.Servicii.Add(s));
            context.SaveChanges();

            var membruEchipa = new List<Echipa>
 {
 new Echipa{Nume = "Dr. Ciobanu Dan", Specializare = "Medic Dentist Generalist", Info="Absolvent UMF Craiova 2013, pasionat de IT si de tenis."},
 new Echipa{Nume = "Dr. Ciobanu Irina", Specializare = "Medic Dentist Generalist", Info="Absolvent UMF Craiova 2013, pasionata de estetica dentara, de citit si de a-si petrece timpul liber in familie."},
 new Echipa{Nume = "Dr. Boeru Alex", Specializare = "Medic Dentist Specialist Chirurgie OMF", Info="Absolvent UMF Craiova 2013, pasionat de pian si iesiri in natura."}

 };
            membruEchipa.ForEach(s => context.Echipe.Add(s));
            context.SaveChanges();

            var preturi = new List<Pret>
            {
                new Pret{Nume = "Consultatie", Valoare = 70},
                new Pret{Nume = "Detartraj cu Ultrasunete", Valoare = 180},
                new Pret{Nume = "Obturatie mica", Valoare = 150},
                new Pret{Nume = "Obturatie medie", Valoare = 180},
                new Pret{Nume = "Obturatie mare", Valoare = 200},
                new Pret{Nume = "Reconstructie Coronara", Valoare = 250},
                new Pret{Nume = "Tratament Canal Monoradicular", Valoare = 200},
                new Pret{Nume = "Tratament Canal Biradicular", Valoare = 250},
                new Pret{Nume = "Tratament Canal Pluriradicular", Valoare = 300},
                new Pret{Nume = "Pansament Calmant", Valoare = 70},
                new Pret{Nume = "Extractie monoradicular", Valoare = 150},
                new Pret{Nume = "Extractie molar", Valoare = 250},
                new Pret{Nume = "Extractie dinte mobil", Valoare = 100},
                new Pret{Nume = "Decapusonare cu Laser", Valoare = 150},
                new Pret{Nume = "Coroana Ceramica/Metal", Valoare = 450},
                new Pret{Nume = "Coroana Ceramica/Zirconiu", Valoare = 700},
                new Pret{Nume = "Proteza Partiala", Valoare = 800},
                new Pret{Nume = "Proteza Totala", Valoare = 800},
                new Pret{Nume = "Proteza Scheletata", Valoare = 2500}
            };
            preturi.ForEach(s => context.Preturi.Add(s));
            context.SaveChanges();
        }
    }
}