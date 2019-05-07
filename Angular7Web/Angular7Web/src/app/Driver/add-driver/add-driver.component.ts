import { Component, OnInit } from '@angular/core';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';
import {DriverService } from '../driver.service';

@Component({
  selector: 'app-add-driver',
  templateUrl: './add-driver.component.html',
  styleUrls: ['./add-driver.component.css']
})
export class AddDriverComponent implements OnInit {

  angForm: FormGroup;

  constructor(private fb : FormBuilder, private driverService : DriverService) {
    this.createForm();
   }

   createForm() {
     this.angForm = this.fb.group({
      driver_firstName: ['', Validators.required ],
      driver_LastName: ['', Validators.required ],
      driver_NIC: ['', Validators.required ]
     })
   }

   addDriver(driver_firstName,driver_LastName, driver_NIC ){
     console.log("Clicked add driver");
    this.driverService.addDriver(driver_firstName, driver_LastName, driver_NIC)
   }

  ngOnInit() {
  }

}
