import { Component, ViewChild } from '@angular/core';
import { NavController, LoadingController, AlertController } from 'ionic-angular';
import { CalendarComponent } from "ionic2-calendar/calendar";
import { DirecionaconexaoServiceProvider } from '../../providers/direcionaconexao-service/direcionaconexao-service';
import { HttpErrorResponse } from '@angular/common/http';
import { Datacheia } from '../../Models/datacheia';
import { HorariolivrePage } from '../horariolivre/horariolivre';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  @ViewChild(CalendarComponent) myCalendar: CalendarComponent;
  public primeiraVez: boolean;
  public datasCheias: Datacheia[];
  event = { startTime: new Date(), endTime: new Date(), allDay: true, title: "Cheio"}
  eventSource = [];
  
  viewTitle:string;
  selectedDay = new Date();
  
  calendar = {
    mode: 'month',
    currentDate: this.selectedDay  
  }
  constructor(public navCtrl: NavController,
    private _loadingCtrl: LoadingController,
    private _alertCtrl: AlertController,
    private direcionaConexaoService: DirecionaconexaoServiceProvider) {
    this.primeiraVez = true;     
  }

  ionViewDidLoad(){
    let loading = this._loadingCtrl.create({
      content: "Aguarde o carregamento..."
  });
  loading.present();

    this.direcionaConexaoService.dias()
    .subscribe(
        (marcacoes) => {
          this.datasCheias = marcacoes;
          console.log(this.datasCheias);
          var events = [];
          for(let data of this.datasCheias){
            let eventInterno = { startTime: new Date(), endTime: new Date(), allDay: true, title: "Cheio"}
            console.log(data.dia, data.mes, data.ano);
          
            eventInterno.startTime = new Date(data.ano,data.mes,data.dia);
            eventInterno.endTime = new Date(data.ano,data.mes,data.dia);
            
            console.log(events);

            let eventData = eventInterno;      
            console.log(eventData);      
            let s = eventData;
            events.push(s);
            console.log(events);
            
            setTimeout(() => {             
            this.eventSource = events;            
          }); 
        }         
          loading.dismiss();
        },
        (err: HttpErrorResponse) => {
          console.log(err);

          loading.dismiss();

          this._alertCtrl.create({
            title:"Falha na conexão",
            subTitle: "Não foi possível carregar",
            buttons: [
              { text: "Ok" }
            ]
          }).present();
        }
      );
  }
  
  onViewTitleChanged(title){
    this.primeiraVez = true;
    this.viewTitle = title;    
  }

  onTimeSelected(ev){
    this.selectedDay = ev.selectedTime;
    if(!this.primeiraVez){
      this.navCtrl.push(HorariolivrePage, {
        diaSelecionado: this.selectedDay
      });
    }
    this.primeiraVez = false;
  }

  onEventSelected(event){}
  
  markDisabled = (date:Date) => {
    var current = new Date();
    current.setHours(0,0,0);
    return date < current; };
}