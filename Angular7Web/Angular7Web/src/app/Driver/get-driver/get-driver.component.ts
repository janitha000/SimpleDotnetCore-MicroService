import { Component, OnInit } from '@angular/core';
import { DriverService } from '../driver.service';
import  Driver  from '../Driver';

@Component({
  selector: 'app-get-driver',
  templateUrl: './get-driver.component.html',
  styleUrls: ['./get-driver.component.css']
})
export class GetDriverComponent implements OnInit {

  drivers : Driver[];
  constructor(private driverService : DriverService) { }

  ngOnInit() {
    this.driverService.getDrivers().subscribe((data : Driver[]) => {
      this.drivers = data;
      console.log(this.drivers[0]);
    })
  }

}
