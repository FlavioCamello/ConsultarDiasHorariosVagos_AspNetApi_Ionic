using consultaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace consultaService.Controllers
{
    public class ConsultasController : ApiController
    {
        //Método retorna todas as datas que estão sem vagas
        // GET api/<controller>
        public IEnumerable<DataCheia> Get()
        {     
            Consulta consulta = new Consulta();           
            List<Consulta> consultas = consulta.retornaLista();
            List<String> diasCheios = new List<string>();
            List<DataCheia> datasCheias = new List<DataCheia>();

            //Insere as consultas em uma lista estática, caso ela esteja vazia
            consulta.preencheLista();

            //Repetidor para preencher lista com datas que estão sem vagas.
            foreach ( Consulta c in consultas)
            {
                int cont = consultas.Count( consults => consults.data == c.data );
                if (cont > 17 && (!diasCheios.Exists( x => x == c.data)))
                {
                    diasCheios.Add(c.data);
                }
            }
            
            //For para percorrer o vetor de dias sem vagas, e formatar-lo para enviar para o aplicativo 
            foreach (String dc in diasCheios)
            {
                var array = dc.Split('-');
                DataCheia dataCheia = new DataCheia(Convert.ToInt32(array[2]), (Convert.ToInt32(array[1]))-1, Convert.ToInt32(array[0]));
                datasCheias.Add(dataCheia);
            }
            return datasCheias; 
        }

        // GET api/<controller>/data
        public IEnumerable<Horario> Get(String data)
        {
            Consulta c = new Consulta();
            String dia, mes, ano, dataExtraida, diaDaSemana;
            Horario horario = new Horario();
            List<Horario> lista = new List<Horario>();

            //retorna todas as consultas
            List<Consulta> consultas = c.retornaLista();

            //Separa o texto Date que chega, e coloca em suas respectivas variáveis
            var array = data.Split(' ');
            dia = array[2];
            ano = array[3];
            mes = c.tranformaMesEmNumero(array[1]);
            diaDaSemana = array[0];

            //Monta a data
            dataExtraida = ano+"-"+mes+"-"+dia;

            //Verifica se é fim de semana. Se não for, irá carregar os horários disponíveis 
            if (diaDaSemana.Equals("Sat") || diaDaSemana.Equals("Sun"))
                lista = horario.semHorarios(true, dataExtraida);
            else           
                lista = horario.carregaHorariosLivres(dataExtraida, consultas);     

            return lista;
        }
    }

    [DataContract]
    public class Horario
    {
        public Horario()
        {
        }

        public Horario(string data, string hora)
        {
            this.data = data;
            this.hora = hora;
        }

        [DataMember]
        public String data { get; set; }
        [DataMember]
        public String hora { get; set; }

        internal List<Horario> carregaHorariosLivres(string dataExtraida, List<Consulta> consultas)
        {
            List<Horario> lista = new List<Horario>();
            List<String> horarios = new List<String>(new string[] {
                "08:00", "08:30", "09:00", "09:30", "10:00","10:30", "11:00", "11:30",
                "13:00", "13:30", "14:00", "14:30", "15:00", "15:30","16:00", "16:30",
                "17:00", "17:30" });
            int cont = 0;
          
            foreach(String hora in horarios){
                cont = 0;
                cont = consultas.Count(consults => consults.data == dataExtraida && consults.hora == hora);
                if (cont < 1)
                    lista.Add(new Horario(dataExtraida, hora));
            }

            if (lista.Count() < 1)
                lista = semHorarios(false, dataExtraida);
                
            return lista;           
        }

        public List<Horario> semHorarios(bool fimdeSemana, String dataExtraida)
        {
            List<Horario> lista = new List<Horario>();
            if (fimdeSemana)
                lista.Add(new Horario(dataExtraida, "Fim de semana"));
            else 
               lista.Add(new Horario(dataExtraida, "Sem horarios vagos"));
            return lista;    
            }
    }

    [DataContract]
    public class DataCheia
    {
        public List<DataCheia> consultas = new List<DataCheia>();

        public DataCheia( int dia, int mes, int ano)
        {          
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        [DataMember]
        public int dia { get; set; }
        [DataMember]
        public int mes { get; set; }
        [DataMember]
        public int ano { get; set; }
    }

    internal class ContadordeDias
    {
        
        public string data { get; set; }
        
        public int cont { get; set; }
    }
}