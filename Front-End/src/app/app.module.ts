import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { LoginComponent } from './components/welcome/login/login.component';
import { MenubarModule } from 'primeng/menubar';
import { CardModule } from 'primeng/card';
import { DividerModule } from 'primeng/divider';
import { PasswordModule } from 'primeng/password';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';
import { LoadingspinnerComponent } from './components/shared/loadingspinner/loadingspinner.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ProgressBarComponent } from './components/shared/progress-bar/progress-bar.component';
import { ProgressBarModule } from 'primeng/progressbar';
import { RegisterComponent } from './components/welcome/register/register.component';
@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    LoginComponent,
    LoadingspinnerComponent,
    ProgressBarComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ButtonModule,
    CalendarModule,
    BrowserAnimationsModule,
    FormsModule,
    InputTextModule,
    MenubarModule,
    CardModule,
    DividerModule,
    CheckboxModule,
    RadioButtonModule,
    PasswordModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    ReactiveFormsModule,ProgressBarModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
