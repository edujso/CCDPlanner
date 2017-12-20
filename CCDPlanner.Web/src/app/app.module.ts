import { BrowserModule } from '@angular/platform-browser';
import { NgModule, enableProdMode } from '@angular/core';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


import { AppComponent } from './app.component';

// Helpers
import { ToastComponent, ToastService } from './blocks/toast';
import { SpinnerComponent, SpinnerService } from './blocks/spinner';
import { ModalComponent, ModalService } from './blocks/modal';
import { ExceptionService } from './blocks/exception.service';
import { FilterTextComponent, FilterService } from './blocks/filter-text';

// Private
import { LoginComponent } from './login/login.component';
import { AdminModule } from './admin/admin.module';

// Services
import { AuthenticationService } from './services/authentication.service';
import { AuthGuard } from "./guards/auth.guard";
import { ProjectComponent } from './project/project.component';
import { CategoryComponent } from './category/category.component';
import { CategoryService } from './services/category.service';

@NgModule({
  declarations: [
    AppComponent,
    ToastComponent,
    SpinnerComponent,
    ModalComponent,
    FilterTextComponent,
    LoginComponent,
    ProjectComponent,
    CategoryComponent

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
    NgbModule.forRoot(),
    AdminModule
  ],
  providers: [
    ToastService,
    SpinnerService,
    ModalService,
    ExceptionService,
    FilterService,
    AuthenticationService,
    CategoryService,
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
