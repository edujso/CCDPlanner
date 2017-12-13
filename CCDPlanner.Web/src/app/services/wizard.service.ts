import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { SpinnerService } from '../blocks/spinner';
import { ExceptionService } from '../blocks/exception.service';
import { ToastService } from '../blocks/toast';

import { WizardConfig } from '../model/wizardConfig';
import { WizardObject } from '../model/wizardObject';
import { AppointmentDetail } from '../model/appointmentDetail';
import { AppointmentType } from '../model/appointmentType';

@Injectable()
export class WizardService {
  constructor(
    private http: Http,
    private _spinnerService: SpinnerService,
    private _exceptionService: ExceptionService,
    private _toastService: ToastService
    ) { }

  public selectedWC: WizardConfig;
  public selectedWO: WizardObject;
  public selectedAT: AppointmentType;

    wizardConfigGetAll() {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/wizardConfigGetAll', this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }
    wizardObjectGetAll() {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/wizardObjectGetAll', this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    appointmentTypeGetAll() {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/appointmentTypeGetAll', this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    appointmentDetailGetAll() {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/appointmentDetailGetAll', this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }


    wizardConfigGetById(id: any) {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/wizardConfigGetById?id=' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    wizardObjectGetById(id: any) {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/wizardObjectGetById?id=' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    appointmentTypeGetById(id: any) {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/appointmentTypeGetById?id=' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    appointmentDetailGetById(id: any) {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/appointmentDetailGetById?id=' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }

    wizardConfigGetByCompanyId(id: any) {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/wizardConfigGetByCompanyId?id=' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }

    wizardObjectGetByWizardConfig(id: any) {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/wizardObjectGetByWizardConfig?id=' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    appointmentDetailGetByAppointmentType(id:any) {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/appointmentDetailGetByAppointmentType?id=' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }

    appointmentTypesGetByWizardObjectId(id: any) {
        this._spinnerService.show();
        return this.http.get('/api/Wizard/appointmentTypesGetByWizardObjectId?id=' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }

    

    wizardConfigInsert(item: any)
    {
        this._spinnerService.show();
        return this.http.post('/api/Wizard/wizardConfigInsert', item, this.jwt())
        .map((response: Response) => response.json())
        .catch(this._exceptionService.catchBadResponse)
        .finally(() => this._spinnerService.hide());
    }
    wizardObjectInsert(item: any) {
        this._spinnerService.show();
        return this.http.post('/api/Wizard/wizardObjectInsert', item, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    appointmentTypeInsert(item: any) {
        this._spinnerService.show();
        return this.http.post('/api/Wizard/appointmentTypeInsert', item, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    appointmentDetailInsert(item: any) {
        this._spinnerService.show();
        return this.http.post('/api/Wizard/appointmentDetailInsert', item, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }

    wizardConfigUpdate(item: any) {
        return this.http.put('/api/Wizard/wizardConfigUpdate', item, this.jwt()).map((response: Response) => response.json());
    }
    wizardObjectUpdate(item: any) {
        return this.http.put('/api/Wizard/wizardObjectUpdate', item, this.jwt()).map((response: Response) => response.json());
    }
    appointmentTypeUpdate(item: any) {
        return this.http.put('/api/Wizard/appointmentTypeUpdate', item, this.jwt()).map((response: Response) => response.json());
    }
    appointmentDetailUpdate(item: any) {
        return this.http.put('/api/Wizard/appointmentDetailUpdate', item, this.jwt()).map((response: Response) => response.json());
    }


    wizardConfigDelete(id: any) {
        this._spinnerService.show();
        return this.http.delete('/api/Wizard/wizardConfigDelete/' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    wizardObjectDelete(id: any) {
        this._spinnerService.show();
        return this.http.delete('/api/Wizard/wizardObjectDelete/' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    appointmentTypeDelete(id: any) {
        this._spinnerService.show();
        return this.http.delete('/api/Wizard/appointmentTypeDelete/' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }
    appointmentDetailDelete(id: any) {
        this._spinnerService.show();
        return this.http.delete('/api/Wizard/appointmentDetailDelete/' + id, this.jwt())
            .map((response: Response) => response.json())
            .catch(this._exceptionService.catchBadResponse)
            .finally(() => this._spinnerService.hide());
    }


   
    // private helper methods
    private jwt() {
        // create authorization header with jwt token
        let currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser && currentUser.token) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
            return new RequestOptions({ headers: headers });
        }
    }
}
