using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace consultaService.Models
{
    [DataContract]
    public class Consulta
    {
        private static List<Consulta> consultas = new List<Consulta>();

        public Consulta()
        {
        }

        public Consulta(int id, string data, string hora)
        {
            this.id = id;
            this.data = data;
            this.hora = hora;
        }

        public List<Consulta> retornaLista()
        {
            return consultas;
        }

        public String tranformaMesEmNumero(string v)
        {
            if (v.Equals("Jan"))
                return "01";
            if (v.Equals("Fev"))
                return "02";
            if (v.Equals("Mar"))
                return "03";
            if (v.Equals("Apr"))
                return "04";
            if (v.Equals("May"))
                return "05";
            if (v.Equals("Jun"))
                return "06";
            if (v.Equals("Jul"))
                return "07";
            if (v.Equals("Aug"))
                return "08";
            if (v.Equals("Sep"))
                return "09";
            if (v.Equals("Oct"))
                return "10";
            if (v.Equals("Nov"))
                return "11";
            if (v.Equals("Dec"))
                return "12";
            return null;
        }

        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string data { get; set; }
        [DataMember]
        public string hora { get; set; }
        
        public List<Consulta> preencheLista()
        {
            if (consultas.Count < 1)
            {         
                consultas.Add(new Consulta(26, "2018-09-25", "08:30"));
                consultas.Add(new Consulta(26, "2018-09-25", "10:30"));
                consultas.Add(new Consulta(5, "2018-09-25", "10:00"));

                consultas.Add(new Consulta(2, "2018-09-26", "12:30"));
                consultas.Add(new Consulta(6, "2018-09-26", "10:00"));
                consultas.Add(new Consulta(26, "2018-09-26", "11:00"));
                consultas.Add(new Consulta(26, "2018-09-26", "14:00"));
                consultas.Add(new Consulta(25, "2018-09-26", "08:00"));
                consultas.Add(new Consulta(23, "2018-09-26", "17:00"));
                consultas.Add(new Consulta(24, "2018-09-26", "17:30"));

                consultas.Add(new Consulta(27, "2018-09-27", "08:00"));
                consultas.Add(new Consulta(28, "2018-09-27", "08:30"));
                consultas.Add(new Consulta(29, "2018-09-27", "09:00"));
                consultas.Add(new Consulta(30, "2018-09-27", "09:30"));
                consultas.Add(new Consulta(31, "2018-09-27", "10:00"));
                consultas.Add(new Consulta(32, "2018-09-27", "10:30"));
                consultas.Add(new Consulta(33, "2018-09-27", "11:00"));
                consultas.Add(new Consulta(34, "2018-09-27", "11:30"));
                consultas.Add(new Consulta(35, "2018-09-27", "13:00"));
                consultas.Add(new Consulta(38, "2018-09-27", "13:30"));
                consultas.Add(new Consulta(37, "2018-09-27", "14:00"));
                consultas.Add(new Consulta(38, "2018-09-27", "14:30"));
                consultas.Add(new Consulta(39, "2018-09-27", "15:00"));
                consultas.Add(new Consulta(40, "2018-09-27", "15:30"));
                consultas.Add(new Consulta(41, "2018-09-27", "16:00"));
                consultas.Add(new Consulta(42, "2018-09-27", "16:30"));
                consultas.Add(new Consulta(43, "2018-09-27", "17:00"));
                consultas.Add(new Consulta(44, "2018-09-27", "17:30"));

                consultas.Add(new Consulta(3, "2018-09-28", "08:00"));
                consultas.Add(new Consulta(4, "2018-09-28", "08:30"));
                consultas.Add(new Consulta(7, "2018-09-28", "09:00"));
                consultas.Add(new Consulta(8, "2018-09-28", "09:30"));
                consultas.Add(new Consulta(9, "2018-09-28", "10:00"));
                consultas.Add(new Consulta(10, "2018-09-28", "10:30"));
                consultas.Add(new Consulta(11, "2018-09-28", "11:00"));
                consultas.Add(new Consulta(12, "2018-09-28", "11:30"));
                consultas.Add(new Consulta(13, "2018-09-28", "13:00"));
                consultas.Add(new Consulta(14, "2018-09-28", "13:30"));
                consultas.Add(new Consulta(15, "2018-09-28", "14:00"));
                consultas.Add(new Consulta(16, "2018-09-28", "14:30"));
                consultas.Add(new Consulta(17, "2018-09-28", "15:00"));
                consultas.Add(new Consulta(18, "2018-09-28", "15:30"));
                consultas.Add(new Consulta(19, "2018-09-28", "16:00"));
                consultas.Add(new Consulta(20, "2018-09-28", "16:30"));
                consultas.Add(new Consulta(21, "2018-09-28", "17:00"));
                consultas.Add(new Consulta(22, "2018-09-28", "17:30"));

                consultas.Add(new Consulta(65, "2018-10-01", "08:00"));
                consultas.Add(new Consulta(66, "2018-10-01", "08:30"));
                consultas.Add(new Consulta(67, "2018-10-01", "09:00"));
                consultas.Add(new Consulta(68, "2018-10-01", "09:30"));
                consultas.Add(new Consulta(69, "2018-10-01", "10:00"));
                consultas.Add(new Consulta(70, "2018-10-01", "10:30"));
                consultas.Add(new Consulta(71, "2018-10-01", "11:00"));
                consultas.Add(new Consulta(72, "2018-10-01", "11:30"));
                consultas.Add(new Consulta(73, "2018-10-01", "13:00"));
                consultas.Add(new Consulta(74, "2018-10-01", "13:30"));
                consultas.Add(new Consulta(75, "2018-10-01", "14:00"));
                consultas.Add(new Consulta(76, "2018-10-01", "14:30"));
                consultas.Add(new Consulta(77, "2018-10-01", "15:00"));
                consultas.Add(new Consulta(78, "2018-10-01", "15:30"));
                consultas.Add(new Consulta(79, "2018-10-01", "16:00"));
                consultas.Add(new Consulta(80, "2018-10-01", "16:30"));
                consultas.Add(new Consulta(81, "2018-10-01", "17:00"));
                consultas.Add(new Consulta(82, "2018-10-01", "17:30"));
                consultas.Add(new Consulta(83, "2018-10-01", "17:00"));
                consultas.Add(new Consulta(84, "2018-10-01", "17:30"));

                consultas.Add(new Consulta(45, "2018-10-02", "08:00"));
                consultas.Add(new Consulta(46, "2018-10-02", "08:30"));
                consultas.Add(new Consulta(47, "2018-10-02", "09:00"));
                consultas.Add(new Consulta(48, "2018-10-02", "09:30"));
                consultas.Add(new Consulta(49, "2018-10-02", "10:00"));
                consultas.Add(new Consulta(50, "2018-10-02", "10:30"));
                consultas.Add(new Consulta(51, "2018-10-02", "11:00"));
                consultas.Add(new Consulta(52, "2018-10-02", "11:30"));
                consultas.Add(new Consulta(53, "2018-10-02", "13:00"));
                consultas.Add(new Consulta(54, "2018-10-02", "13:30"));
                consultas.Add(new Consulta(55, "2018-10-02", "14:00"));
                consultas.Add(new Consulta(56, "2018-10-02", "14:30"));
                consultas.Add(new Consulta(57, "2018-10-02", "15:00"));
                consultas.Add(new Consulta(58, "2018-10-02", "15:30"));
                consultas.Add(new Consulta(59, "2018-10-02", "16:00"));
                consultas.Add(new Consulta(60, "2018-10-02", "16:30"));
                consultas.Add(new Consulta(61, "2018-10-02", "17:00"));
                consultas.Add(new Consulta(62, "2018-10-02", "17:30"));
                consultas.Add(new Consulta(63, "2018-10-02", "17:00"));
                consultas.Add(new Consulta(64, "2018-10-02", "17:30"));

                consultas.Add(new Consulta(65, "2018-10-05", "12:30"));
                consultas.Add(new Consulta(66, "2018-10-05", "10:00"));
                consultas.Add(new Consulta(67, "2018-10-05", "11:00"));
                consultas.Add(new Consulta(68, "2018-10-05", "14:00"));
                consultas.Add(new Consulta(69, "2018-10-05", "08:00"));
                consultas.Add(new Consulta(70, "2018-10-05", "17:00"));
                consultas.Add(new Consulta(71, "2018-10-05", "17:30"));
            }
                return consultas;
        }
    }
}