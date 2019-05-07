import { Component, OnInit } from '@angular/core';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';

@Component({
  selector: 'app-add-driver',
  templateUrl: './add-driver.component.html',
  styleUrls: ['./add-driver.component.css']
})
export class AddDriverComponent implements OnInit {

  angForm: FormGroup;

  constructor(private fb : FormBuilder) {
    this.createForm();
   }

   createForm() {
     this.angForm = this.fb.group({
      driver_firstName: ['', Validators.required ],
      driver_LastName: ['', Validators.required ],
      driver_NIC: ['', Validators.required ]
     })
   }

  ngOnInit() {
  }

}
