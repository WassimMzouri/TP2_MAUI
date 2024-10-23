using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_.net.Models
{
    internal class CListeNotes
    {
        public ObservableCollection<CNote> CollNotes { get; set; } = new ObservableCollection<CNote>();

        public CListeNotes() => ChargerNotes();

        public void ChargerNotes()
        {
            string maVar = FileSystem.AppDataDirectory;

            IEnumerable<CNote> listenote = Directory.EnumerateFiles(maVar, "*.notes.txt").Select(filename => new CNote()
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                }).OrderBy(note => note.Date);

            foreach (CNote note in listenote)
            {
                CollNotes.Add(note);
            }

        }

    }
}
