using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.SII.Entities.Request
{
    public class FileMetaDataModel
    {

        public string FileName { get; set; }
        public string FileNameWithoutExtension { get; set; }
        public string FileExtention { get; set; }
        public string FileMimeType { get; set; }
        public string DocumentType { get; set; }
        public string Agency { get; set; }
        public string Identifier { get; set; }
        public DateTime Date { get; set; }
    }
    public class ProcessFileQueueRequest
    {

        public Guid Id { get; set; }
        public string AgencyId { get; set; }
        public string Identifier { get; set; }
        public string FileName { get; set; }
        public FileMetaDataModel FileMetaData { get; set; }
    }
    public class ConsultaFacturasRequest
    {
        public string IdAgencia { get; set; }
        public string IdLibroRegistro { get; set; }
        public int Ejercicio { get; set; }
        public string Periodo { get; set; }
        public string CompanyNif { get; internal set; }
        public string CompanyDenomination { get; internal set; }
    }
}
