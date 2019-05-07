import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {AddDriverComponent } from './Driver/add-driver/add-driver.component';
import {EditDriverComponent } from './Driver/edit-driver/edit-driver.component';
import {GetDriverComponent } from './Driver/get-driver/get-driver.component';

const routes: Routes = [
  { path : 'dirver/create', component : AddDriverComponent},
  { path : 'dirver/edit/:id', component : EditDriverComponent},
  { path : 'dirver', component : GetDriverComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
