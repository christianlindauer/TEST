using AutoReservation.Common.DataTransferObjects.Core;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class AutoDto : DtoBase<AutoDto>
    {
        private int tagesTarif;

        [DataMember]
        public int Tagestarif
        {
            get { return tagesTarif; }
            set
            {
                if (tagesTarif != value)
                {
                    tagesTarif = value;
                    OnPropertyChanged(nameof(Tagestarif));
                }
            }
        }

        private string marke;

        [DataMember]
        public string Marke
        {
            get { return marke; }
            set
            {
                if (marke != value)
                {
                    marke = value;
                    OnPropertyChanged(nameof(Marke));
                }
            }
        }

        private int? basisTarif;


        [DataMember]
        public int? Basistarif
        {
            get { return basisTarif; }
            set
            {
                if (basisTarif != value)
                {
                    basisTarif = value;
                    OnPropertyChanged(nameof(Basistarif));
                }
            }
        }

        private int id;

        [DataMember]
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private AutoKlasse autoKlasse;

        [DataMember]
        public AutoKlasse AutoKlasse
        {
            get { return autoKlasse; }
            set
            {
                if (autoKlasse != value)
                {
                    autoKlasse = value;
                    OnPropertyChanged(nameof(AutoKlasse));
                }
            }
        }

        private byte[] rowVersion;

        [DataMember]
        public byte[] RowVersion
        {
            get { return rowVersion; }
            set
            {
                if (rowVersion != value)
                {
                    rowVersion = value;
                    OnPropertyChanged(nameof(RowVersion));
                }
            }
        }

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
