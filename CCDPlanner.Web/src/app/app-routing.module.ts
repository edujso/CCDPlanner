import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { LoginComponent } from './login/login.component';
import { ProjectComponent } from './project/project.component';

import { AuthGuard } from "./guards/auth.guard";

const routes: Routes = [
  //{ path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: '', component: AdminComponent, canActivate: [AuthGuard],
    children: [
      { path: 'projects', component: ProjectComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
