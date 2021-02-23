import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http'; 
import { RouterModule, Routes } from '@angular/router'; 
import { FlashMessagesModule, FlashMessagesService } from 'angular2-flash-messages';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ConsultansComponent } from './components/consultans/consultans.component';
import { ConsultantService } from './services/consultant.service';
import { HomeComponent } from './components/home/home.component';
import { ConsultantDetailComponent } from './components/consultant-detail/consultant-detail.component';
import { EditConsultantComponent } from './components/edit-consultant/edit-consultant.component';
import { AddConsultantComponent } from './components/add-consultant/add-consultant.component';

const appRoutes: Routes = [   
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'consultant-detail/:id', component: ConsultantDetailComponent },
  { path: 'consultants', component: ConsultansComponent }, 
  { path: '**', redirectTo: 'consultants' }  
];

@NgModule({
  declarations: [
    AppComponent,
    ConsultansComponent,
    HomeComponent,
    ConsultantDetailComponent,
    EditConsultantComponent,
    AddConsultantComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    NgbModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    FlashMessagesModule.forRoot()  
  ],
  providers: [ConsultantService],
  bootstrap: [AppComponent]
})
export class AppModule { }
