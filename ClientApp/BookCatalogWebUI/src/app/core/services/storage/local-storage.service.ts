import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  private readonly PREFIX = 'bookDialog_';

  saveFormData(formName: string, data: any): void {
    localStorage.setItem(this.PREFIX + formName, JSON.stringify(data));
  }

  getFormData(formName: string): any {
    const data = localStorage.getItem(this.PREFIX + formName);
    return data ? JSON.parse(data) : null;
  }

  clearFormData(formName: string): void {
    localStorage.removeItem(this.PREFIX + formName);
  }
}
