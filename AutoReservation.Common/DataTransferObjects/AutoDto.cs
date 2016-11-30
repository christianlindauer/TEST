using AutoReservation.Common.DataTransferObjects.Core;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{


    public class AutoDto : DtoBase<AutoDto>
    {
        public int Tagestarif { get; set; }
        public string Marke { get; set; }
        public int Basistarif { get; set; }
        public int Id { get; set; }
        public AutoKlasse AutoKlasse { get; set; }
        public byte[] RowVersion { get; set; }

        public AutoDto(int basistarif, int id, string marke, int tagestarif, AutoKlasse klasse, byte[] rowVersion)
        {
            Basistarif = basistarif;
            Id = id;
            Marke = marke;
            Tagestarif = tagestarif;
            AutoKlasse = klasse;
            RowVersion = rowVersion;

        }

        public AutoDto()
        {

        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Marke))
            {
                error.AppendLine("- Marke ist nicht gesetzt.");
            }
            if (Tagestarif <= 0)
            {
                error.AppendLine("- Tagestarif muss grösser als 0 sein.");
            }
            if (AutoKlasse == AutoKlasse.Luxusklasse && Basistarif <= 0)
            {
                error.AppendLine("- Basistarif eines Luxusautos muss grösser als 0 sein.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override string ToString()
            => $"{Id}; {Marke}; {Tagestarif}; {Basistarif}; {AutoKlasse}";

    }
}
