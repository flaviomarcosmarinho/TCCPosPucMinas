import { Injectable } from '@angular/core';
import { SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor() { }

  private showAlert(titulo: string, mensagem: string, icone: SweetAlertIcon) : void {

  }
}
