import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { NumberComponent } from './components/number/number.component';
// import { NumberResultModel } from './models/number-result/number-result.model';
// import { InputNumberModel } from './models/input-number/input-number.model';
import { NumberService } from './services/number.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbSidebarModule, NbMenuModule, NbButtonModule, NbCardModule, NbIconModule, NbInputModule, NbDatepickerModule, NbListModule, NbToastrModule, NbTableModule, NbRouteTabsetModule, NbTabsetModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { HomeComponent } from './components/home/home.component';

import { MtgComponent } from './components/mtg/mtg.component';
import { MtgDetailsComponent } from './components/mtg-details/mtg-details.component';
import { MtgService } from './services/mtg.service';


@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    NumberComponent,
    HomeComponent,
    MtgComponent,
    MtgDetailsComponent,
    // NumberResultModel,
    // InputNumberModel
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'dark' }),
    NbLayoutModule,
    NbSidebarModule.forRoot(),
    NbMenuModule.forRoot(),
    NbButtonModule,
    NbCardModule,
    NbIconModule,
    NbInputModule,
    NbDatepickerModule.forRoot(),
    HttpClientModule,
    NbListModule,
    NbToastrModule.forRoot(),
    NbEvaIconsModule,
    FormsModule,
    ReactiveFormsModule,
    NbTableModule,
    NbRouteTabsetModule,
    NbTabsetModule
  ],
  providers: [
    // { provide: HTTP_INTERCEPTORS, useClass: HttpResponseInterceptor, multi: true },
    NumberService,
    MtgService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
