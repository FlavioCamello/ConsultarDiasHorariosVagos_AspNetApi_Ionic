# Sobre
funcionalidade para um app (Cordova/Ionic) de uma clínica médica. Essa funcionalidade lista os dias disponíveis para agendamento e ao clicar no dia são exibidos os horários. Os dados dos dias e horários são obtidos do backend que foi desenvolvido com ASP.NET WebAPI.

Dois projetos estão nas pastas. A pasta Consults, está o projeto feito para Ionic. E a pasta consultaService, é uma api feita em Asp.Net.

# Versóes
Ionic 3.16.0
Cordova 7.0.1
Para o calendario foi utilizado o ionic2-calendar

# Para Utilizar
A API, basta rodar. 

A parte do ionic, deve-se ir até a pasta providers->direcionarconexao-service e abrir o arquivo direcionarconexao-service.ts. Vá ao método dias, e coloque o http da api. Faça o mesmo no arquivo horario-service.ts no método lista(dia). 

# Adicionar mais agendamentos
Para adicionar mais agendamentos dentro da API, deve-se ir a pasta model->Consulta.cs, e no método preencheLista adicione quantos agendamentos achar necessario. 
