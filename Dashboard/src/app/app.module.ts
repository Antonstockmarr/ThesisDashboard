import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatStepperModule} from '@angular/material/stepper';






import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Page2Component } from './page2/page2.component';
import { Page1Component } from './page1/page1.component';
import { CheckboxLineComponent } from './subcomponents/checkbox-line/checkbox-line.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DifficultyBarComponent } from './subcomponents/difficulty-bar/difficulty-bar.component';
import { ContentcardComponent } from './subcomponents/contentcard/contentcard.component';
import { FooterComponent } from './subcomponents/footer/footer.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LocalStorageComponent } from './local-storage/local-storage.component';
import { LocalStorageService } from './services/local-storage.service';
import { HttpClientModule } from '@angular/common/http';
import { Page3Component } from './page3/page3.component';
import { Page4Component } from './page4/page4.component';

@NgModule({
  declarations: [
    AppComponent,
    Page1Component,
    Page2Component,
    CheckboxLineComponent,
    DifficultyBarComponent,
    ContentcardComponent,
    FooterComponent,
    LocalStorageComponent,
    Page3Component,
    Page4Component,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MatCheckboxModule,
    MatCardModule,
    MatGridListModule,
    MatStepperModule,
    FontAwesomeModule,
    HttpClientModule
  ],
  providers: [LocalStorageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
