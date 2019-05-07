import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class DriverService {
  url = 'http://localhost:5000/api/driver'

  constructor(private http: HttpClient) {

  }

  addDriver(driver_firstName, driver_LastName, driver_NIC) {
    const obj = {
      FirstName: driver_firstName,
      LastName: driver_LastName,
      NIC: driver_NIC
    };
    console.log(obj);
    this.http.post(`${this.url}`, obj)
      .subscribe(res => console.log('Done'));
  }

  getDrivers() {
    return this.http.get(`${this.url}`);
  }
}
