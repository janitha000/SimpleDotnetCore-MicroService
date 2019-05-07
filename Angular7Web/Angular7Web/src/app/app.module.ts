import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { SlimLoadingBarModule } from 'ng2-slim-loading-bar';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EditDriverComponent } from './Driver/edit-driver/edit-driver.component';
import { GetDriverComponent } from './Driver/get-driver/get-driver.component';
import { AddDriverComponent } from './Driver/add-driver/add-driver.component';

@NgModule({
  declarations: [
    AppComponent,
    EditDriverComponent,
    GetDriverComponent,
    AddDriverComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SlimLoadingBarModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
