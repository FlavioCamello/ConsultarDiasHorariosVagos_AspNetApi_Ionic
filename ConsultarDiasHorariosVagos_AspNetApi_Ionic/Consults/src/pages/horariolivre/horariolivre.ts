import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController, LoadingController } from 'ionic-angular';
import { HorarioServiceProvider } from '../../providers/horario-service/horario-service';
import { Horario } from '../../Models/horario';
import { HttpErrorResponse } from '@angular/common/http';

@IonicPage()
@Component({
  selector: 'page-horariolivre',
  templateUrl: 'horariolivre.html',
})
export class HorariolivrePage {

  public diaSelecionado;
  public horarios: Horario[];
  constructor(public navCtrl: NavController, 
    public navParams: NavParams,
    private _alertCtrl: AlertController,
    private _loadingCtrl: LoadingController,
    private horarioService: HorarioServiceProvider) {
      this.diaSelecionado = this.navParams.get('diaSelecionado');
  }

  ionViewDidLoad() {
    let loading = this._loadingCtrl.create({
      content: "Aguarde o carregamento..."
  });
  loading.present();

    this.horarioService.lista(this.diaSelecionado)
    .subscribe(
        (horarios) => {
          this.horarios = horarios;           
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
}
