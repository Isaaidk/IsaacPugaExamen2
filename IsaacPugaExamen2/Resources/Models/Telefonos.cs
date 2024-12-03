using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaacPugaExamen2.Resources.Models
{
    internal class Telefonos
    {
        public ObservableCollection<IPTelefono> Notes { get; set; } = new ObservableCollection<IPTelefono>();

        public Telefonos() =>
            LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<IPTelefono> notes = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.notes.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new IPTelefono()
                                        {
                                            Filename = filename,
                                            Telefono = File.ReadAllText(filename),
                                            Nombre = File.ReadAllText(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(note => note.Nombre);

            // Add each note into the ObservableCollection
            foreach (IPTelefono note in notes)
                Notes.Add(note);
        }
    }
}
}
