import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';




import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Page2Component } from './page2/page2.component';
import { Page1Component } from './page1/page1.component';
import { CheckboxLineComponent } from './checkbox-line/checkbox-line.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    Page1Component,
    Page2Component,
    CheckboxLineComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MatCheckboxModule,
    MatCardModule,
    MatGridListModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
